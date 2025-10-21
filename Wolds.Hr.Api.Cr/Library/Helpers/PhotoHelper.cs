﻿using Wolds.Hr.Api.Cr.Library.Helpers.Interfaces;

namespace Wolds.Hr.Api.Cr.Library.Helpers;

internal sealed class PhotoHelper : IPhotoHelper
{
    public PhotoHelper() { }

    public record EditPhoto(bool PhotoWasChanged, string OriginalPhotoName);

    public bool NotDefaultImage(string fileName, string defaultPhotoFilename)
    {
        if (!string.IsNullOrEmpty(fileName) && fileName != defaultPhotoFilename)
            return true;
        else
            return false;
    }

    public EditPhoto WasPhotoEdited(string originalPhotoFileName, string newPhotoFileName, string defaultPhotoFilename)
    {
        return new EditPhoto(originalPhotoFileName != null && newPhotoFileName != null && NotDefaultImage(originalPhotoFileName, defaultPhotoFilename)
                                    && originalPhotoFileName != newPhotoFileName, originalPhotoFileName);
    }
}