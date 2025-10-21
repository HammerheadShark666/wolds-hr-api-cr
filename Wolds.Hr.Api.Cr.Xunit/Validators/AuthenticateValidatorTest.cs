﻿using FluentValidation;
using Moq;
using Wolds.Hr.Api.Cr.Data.Interfaces;
using Wolds.Hr.Api.Cr.Domain;
using Wolds.Hr.Api.Cr.Library.Dto.Requests;
using Wolds.Hr.Api.Cr.Validator;

namespace Wolds.Hr.Api.Cr.Xunit.Validators;

public class AuthenticateValidatorTests
{
    private readonly Mock<IAccountRepository> _accountRepoMock;
    private readonly AuthenticateValidator _validator;

    public AuthenticateValidatorTests()
    {
        _accountRepoMock = new Mock<IAccountRepository>();
        _validator = new AuthenticateValidator(_accountRepoMock.Object);
    }

    [Theory]
    [InlineData("", "Password123!", "Username is required.")]
    [InlineData("short", "Password123!", "Username length between 8 and 150.")]
    [InlineData("not-an-email", "Password123!", "Invalid Username.")]
    public async Task Username_Should_FailValidation(string username, string password, string expectedMessage)
    {
        var request = new LoginRequest(username, password);

        var result = await _validator.ValidateAsync(request, options => options.IncludeRuleSets("LoginValidation"));

        var usernameError = result.Errors.FirstOrDefault(e => e.PropertyName == "Username");

        Assert.NotNull(usernameError);
        Assert.Equal(expectedMessage, usernameError.ErrorMessage);
    }

    [Theory]
    [InlineData("", "Password is required.")]
    [InlineData("short", "Password length between 8 and 50.")]
    public async Task Password_Should_FailValidation(string password, string expectedMessage)
    {
        var request = new LoginRequest("user@example.com", password);

        var result = await _validator.ValidateAsync(request, opts => opts.IncludeRuleSets("LoginValidation"));

        var passwordError = result.Errors.FirstOrDefault(e => e.PropertyName == "Password");

        Assert.NotNull(passwordError);
        Assert.Equal(expectedMessage, passwordError.ErrorMessage);
    }

    [Fact]
    public async Task ValidLoginDetails_Should_Fail_When_AccountDoesNotExist()
    {
        _accountRepoMock.Setup(r => r.Get("user@example.com"))
            .Returns((Account?)null);

        var request = new LoginRequest("user@example.com", "Password123!");

        var result = await _validator.ValidateAsync(request, opts => opts.IncludeRuleSets("LoginValidation"));

        var invalidLoginError = result.Errors.FirstOrDefault(e => e.PropertyName == "");

        Assert.NotNull(invalidLoginError);
        Assert.Equal("Invalid login", invalidLoginError.ErrorMessage);
    }

    [Fact]
    public async Task ValidLoginDetails_Should_Fail_When_PasswordDoesNotMatch()
    {
        var account = new Account
        {
            Email = "user@example.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("CorrectPassword")
        };

        _accountRepoMock.Setup(r => r.Get("user@example.com"))
            .Returns(account);

        var request = new LoginRequest("user@example.com", "WrongPassword");

        var result = await _validator.ValidateAsync(request, opts => opts.IncludeRuleSets("LoginValidation"));

        var invalidLoginError = result.Errors.FirstOrDefault(e => e.PropertyName == "");

        Assert.NotNull(invalidLoginError);
        Assert.Equal("Invalid login", invalidLoginError.ErrorMessage);
    }

    [Fact]
    public async Task ValidLoginDetails_Should_Pass_When_CredentialsAreCorrect()
    {
        var password = "TestPassword";
        var account = new Account
        {
            Email = "user@example.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            Verified = DateTime.Now
        };

        _accountRepoMock.Setup(r => r.Get("user@example.com"))
            .Returns(account);

        var request = new LoginRequest("user@example.com", password);

        var result = await _validator.ValidateAsync(request, opts => opts.IncludeRuleSets("LoginValidation"));

        Assert.True(result.IsValid);
    }
}
