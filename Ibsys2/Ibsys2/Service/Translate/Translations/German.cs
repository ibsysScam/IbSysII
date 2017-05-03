using System;
using System.Collections.Generic;
using Ibsys2.Service;
using static Ibsys2.Service.TranslateService;


namespace Ibsys2.Service {
    public static class GermanTranslation {
        private static Dictionary<string, string> _translate = new Dictionary<string, string>();

        public static void AddLanguage() {
            Translate();
            TranslateService.Class.AddTranslation(new Language("de", "Deutsch"), _translate);
        }

        private static void Translate() {
            _translate.Add("HELLO", "Hallo");
            _translate.Add("SETTINGS_SAVED", "Einstellungen gespeichert!");
            _translate.Add("SETTINGS", "Einstellungen");
        }
        
    }
    
}