using CookBook.Models.Settings;
using CookBook.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookBook.Services.Core;
public class SettingsService : ISettingsService
{
    private readonly ISettings _settings;
    private readonly IFileService _fileService;

    public SettingsService(
        ISettings settings,
        IFileService fileService)
    { 
        _settings = settings;
        _fileService = fileService;
    }

    public void SaveSettings()
    {
        string data = JsonSerializer.Serialize((Settings)_settings, new JsonSerializerOptions { WriteIndented = true });
        _fileService.WriteFile(new FileInfo(Constants.APP_SETTING_PATH), data);
    }
}

