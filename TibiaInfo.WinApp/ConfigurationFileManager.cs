using System;
using System.Configuration;
using System.Windows.Forms;
using TibiaInfo.WinApp.Config;

namespace TibiaInfo.WinApp
{
    public class ConfigurationFileManager
    {
        private readonly Configuration _configuration;
        private readonly KeyValueConfigurationCollection _settings;

        public ConfigurationFileManager()
        {
            _configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _settings = _configuration.AppSettings.Settings;
        }
        
        public Settings loadConfigFile()
        {
            var settings = new Settings();

            settings.CharacterName = _settings["CharacterName"].Value;
            settings.HuntingSessionScanner = Convert.ToBoolean(_settings["HuntingSessionScanner"].Value);
            settings.TibiaDirectoryLocation = _settings["TibiaDirectoryLocation"].Value;

            return settings;
        }

        public void saveConfigFile(string characterName, bool value)
        {
            try
            {
                _settings["CharacterName"].Value = characterName;
                _settings["HuntingSessionScanner"].Value = Convert.ToString(value);

                _configuration.Save(ConfigurationSaveMode.Modified);
            }
            catch (ConfigurationErrorsException ex)
            {
                throw ex;
            }
        }

        public void setCharacterName(string characterName)
        {
            try
            {
                _settings["CharacterName"].Value = characterName;
                _configuration.Save(ConfigurationSaveMode.Modified);
            }
            catch (ConfigurationErrorsException ex)
            {
                throw ex;
            }
        }

        public void setHuntingSessionScanner(bool value)
        {
            try
            {
                _settings["HuntingSessionScanner"].Value = Convert.ToString(value);
                _configuration.Save(ConfigurationSaveMode.Modified);
            }
            catch (ConfigurationErrorsException ex)
            {
                throw ex;
            }
        }
        
        public void setTibiaDirectoryLocation(string directoryLocation)
        {
            try
            {
                _settings["TibiaDirectoryLocation"].Value = Convert.ToString(directoryLocation);
                _configuration.Save(ConfigurationSaveMode.Modified);
            }
            catch (ConfigurationErrorsException ex)
            {
                throw ex;
            }
        }
    }
}