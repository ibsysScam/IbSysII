using System;
using System.Collections.Generic;
using Ibsys2.Service;
using static Ibsys2.Service.TranslateService;


namespace Ibsys2.Service {
    public static class EnglishTranslation {
        private static Dictionary<string, string> _translate = new Dictionary<string, string>();

        public static void AddLanguage() {
            Translate();
            TranslateService.Class.AddTranslation(new Language("en", "English"), _translate);
        }

        private static void Translate() {
            _translate.Add("HELLO", "Hello");
            _translate.Add("SETTINGS_SAVED", "Settings saved! Would you like to restart the Program? Without a restart translate errors will occur!");
            _translate.Add("SETTINGS", "Settings");
            _translate.Add("XML_ERROR", "This is not a XML File!");
            _translate.Add("ONLY_INT_ERROR", "Please use only integer values!");
        }

    }

}