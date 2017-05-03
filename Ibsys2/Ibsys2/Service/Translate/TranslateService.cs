using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Service {
    public class TranslateService {
        private static TranslateService _class;
        private Dictionary<Language, LanguageDictionary> _dictionary;
        private Language _primaryLanguage;
        private Language _fallbackLanguage;

        private void LoadTranslations() {
            GermanTranslation.AddLanguage();
            EnglishTranslation.AddLanguage();
            FallbackLanguage = "de";
            PrimaryLanguage = "en";
        }

        public static TranslateService Class {
            get {
                if (_class == null)
                    new TranslateService();
                return _class;
            }
        }

        public string PrimaryLanguage {
            get {
                return _primaryLanguage.LanguageShortText;
            }

            set {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                value = value.ToLower();
                if (!ExistsLanguage(value))
                    throw new Exception("Language does not exist!");
                _primaryLanguage = FindLanguage(value);
            }
        }

        public Language GetPrimaryLanguage {
            get {
                return _primaryLanguage;
            }
        }

        public Language GetFallbackLanguage {
            get {
                return _fallbackLanguage;
            }
        }

        public string FallbackLanguage {
            get {
                return _fallbackLanguage.LanguageShortText;
            }

            set {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                value = value.ToLower();
                if (!ExistsLanguage(value))
                    throw new Exception("Language does not exist!");
                _fallbackLanguage = FindLanguage(value);
            }
        }

        public TranslateService() {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            _dictionary = new Dictionary<Language, LanguageDictionary>();

            LoadTranslations();
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

        public void AddTranslation(Language language, string key, string translation) {
            if (String.IsNullOrEmpty(key) || String.IsNullOrEmpty(translation))
                throw new ArgumentNullException();
            if (!ExistsLanguage(language))
                _dictionary[language] = new LanguageDictionary(language);
            _dictionary[language].AddTranslation(key, translation);
        }

        public void AddTranslation(Language language, Dictionary<string, string> input) {
            if (language == null || input == null)
                throw new ArgumentNullException();
            if (!ExistsLanguage(language))
                _dictionary[language] = new LanguageDictionary(language);
            _dictionary[language].AddTranslation(input);
        }

        private bool ExistsLanguage(string language) {
            if (String.IsNullOrEmpty(language))
                throw new ArgumentNullException();
            var foundLang = FindLanguage(language);
            if (foundLang == null)
                return false;
            return ExistsLanguage(foundLang);
        }

        private bool ExistsLanguage(Language language) {
            if (language == null)
                throw new ArgumentNullException();
            return _dictionary.ContainsKey(language);
        }

        public List<Language> GetLanguages() {
            List<Language> l = new List<Language>();

            foreach (var key in _dictionary.Keys)
                l.Add(key);
            return l;
        }

        private Language FindLanguage(string language) {
            if (String.IsNullOrEmpty(language))
                throw new ArgumentNullException();
            foreach (var key in _dictionary.Keys) {
                if (language.ToLower() == key.LanguageShortText.ToLower())
                    return key;
            }

            foreach (var key in _dictionary.Keys) {
                if (language.ToLower() == key.LanguageLongText.ToLower())
                    return key;
            }
            return null;
        }

        public void ClearClass() {
            _class = null;
            _dictionary = null;
        }


        protected class LanguageDictionary {
            private Language _language;
            private Dictionary<string, string> _dictionary;

            public LanguageDictionary(Language _language) {
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
            private string _lang;
            private string _langLongText;

            public Language(string _lang, string _langLongText) {
                this._lang = _lang;
                this._langLongText = _langLongText;
            }

            public string LanguageShortText {
                get {
                    return _lang;
                }
            }

            public string LanguageLongText {
                get {
                    return _langLongText;
                }
            }
        }
    }
}
