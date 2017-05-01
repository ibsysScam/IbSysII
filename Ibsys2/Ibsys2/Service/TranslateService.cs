using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Service {
    public class TranslateService {
        private static TranslateService _class;
        private Dictionary<string, LanguageDictionary> _dictionary;
        private string _primaryLanguage = "de";
        private string _fallbackLanguage = "en";

        public static TranslateService Class {
            get {
                if (_class == null)
                    new TranslateService();
                return _class;
            }
        }

        public string PrimaryLanguage {
            get {
                return _primaryLanguage;
            }

            set {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                value = value.ToLower();
                if (!existsLanguage(value))
                    throw new Exception("Language does not exist!");
                _primaryLanguage = value;
            }
        }

        public string FallbackLanguage {
            get {
                return _fallbackLanguage;
            }

            set {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                value = value.ToLower();
                if (!existsLanguage(value))
                    throw new Exception("Language does not exist!");
                _fallbackLanguage = value;
            }
        }

        public TranslateService() {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            _dictionary = new Dictionary<string, LanguageDictionary>();
        }

        public string GetTranslation(string key) {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException();
            string translation = "";
            translation = _dictionary[_primaryLanguage].GetTranslation(key);
            if (String.IsNullOrEmpty(translation))
                translation = _dictionary[_fallbackLanguage].GetTranslation(key);
            if (String.IsNullOrEmpty(translation))
                translation = key;
            return translation;
        }

        public void AddTranslation(string language, string key, string translation) {
            if (String.IsNullOrEmpty(language) || String.IsNullOrEmpty(key) || String.IsNullOrEmpty(translation))
                throw new ArgumentNullException();
            language = language.ToLower();
            if (!existsLanguage(language))
                _dictionary[language] = new LanguageDictionary(language);
            _dictionary[language].AddTranslation(key, translation);
        }

        public void AddTranslation(string language, Dictionary<string, string> input) {
            if (String.IsNullOrEmpty(language) || input == null)
                throw new ArgumentNullException();
            language = language.ToLower();
            if (!existsLanguage(language))
                _dictionary[language] = new LanguageDictionary(language);
            _dictionary[language].AddTranslation(input);
        }

        private bool existsLanguage(string language) {
            if (String.IsNullOrEmpty(language))
                throw new ArgumentNullException();
            return _dictionary.ContainsKey(language.ToLower());
        }

        public void ClearClass() {
            _class = null;
            _dictionary = null;
        }


        protected class LanguageDictionary {
            private string _language;
            private Dictionary<string, string> _dictionary;

            public LanguageDictionary(string _language) {
                this._language = _language;
                this._dictionary = new Dictionary<string, string>();
            }

            public string GetTranslation(string key) {
                if (String.IsNullOrEmpty(key))
                    return null;
                if (_dictionary.ContainsKey(key))
                    return _dictionary[key];
                return null;
            }

            public void AddTranslation(string key, string translation) {
                if (String.IsNullOrEmpty(key) || String.IsNullOrEmpty(translation))
                    throw new ArgumentNullException();
                _dictionary.Remove(key);
                _dictionary[key] = translation;
            }

            public void AddTranslation(Dictionary<string, string> input) {
                if (input == null)
                    throw new ArgumentNullException();
                foreach (var Eintarg in input) {
                    if (String.IsNullOrEmpty(Eintarg.Key) || String.IsNullOrEmpty(Eintarg.Value))
                        continue;
                    _dictionary.Remove(Eintarg.Key);
                    _dictionary[Eintarg.Key] = Eintarg.Value;
                }
            }
        }
        public class Language {

        }
    }
}
