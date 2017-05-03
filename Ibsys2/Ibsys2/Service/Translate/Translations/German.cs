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
            _translate.Add("SETTINGS_SAVED", "Einstellungen gespeichert! Möchten Sie das Programm neustarten? Ohne Neustart kann es zu Problemen bei der Übersetzung kommen!");
            _translate.Add("SETTINGS", "Einstellungen");
            _translate.Add("XML_ERROR", "Das ist keine XML File!");
            _translate.Add("ONLY_INT_ERROR", "Bitte benutze nur Ganzzahlen!");
        }
        
    }
    
}