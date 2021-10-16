using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessEntity;

namespace BLL.Hardcodes
{
    public class Tables
    {
        private List<Item> _headerTypes;
        public List<Item> HeaderTypes
        {
            get
            {
                if (_headerTypes == null)
                {
                    _headerTypes = new List<Item>();

                    foreach (int item in Enum.GetValues(typeof(Subjects.BannerTypes)))
                    {
                        _headerTypes.Add(new Item(item, Farschidus.Translator.AppTranslate["headerTypes.title." + ((Subjects.BannerTypes)item).ToString()]));
                    }
                }
                return _headerTypes;
            }
        }

        private List<Item> _galleryTypes;
        public List<Item> GalleryTypes
        {
            get
            {
                if (_galleryTypes == null)
                {
                    _galleryTypes = new List<Item>();

                    foreach (int item in Enum.GetValues(typeof(Gallery.Types)))
                    {
                        _galleryTypes.Add(new Item(item, Farschidus.Translator.AppTranslate["galleryTypes.title." + ((Gallery.Types)item).ToString()]));
                    }
                }
                return _galleryTypes;
            }
        }

        private List<Item> _subjectTypes;
        public List<Item> SubjectTypes
        {
            get
            {
                if (_subjectTypes == null)
                {
                    _subjectTypes = new List<Item>();
                    foreach (int item in Enum.GetValues(typeof(SubjectTypes.Enum)))
                    {
                        _subjectTypes.Add(new Item(item, Farschidus.Translator.AppTranslate["subjectTypes.title." + ((SubjectTypes.Enum)item).ToString()]));
                    }
                }
                return _subjectTypes;
            }
        }

        private List<Item> _mediaSubjectTypes;
        public List<Item> MediaSubjectTypes
        {
            get
            {
                if (_mediaSubjectTypes == null)
                {
                    _mediaSubjectTypes = new List<Item>();
                    foreach (int item in Enum.GetValues(typeof(MediaSubjectTypes.Enum)))
                    {
                        _mediaSubjectTypes.Add(new Item(item, Farschidus.Translator.AppTranslate["mediaSubjectTypes.title." + ((MediaSubjectTypes.Enum)item).ToString()]));
                    }
                }
                return _mediaSubjectTypes;
            }
        }

        private List<Item> _translatorTypes;
        public List<Item> TranslatorTypes
        {
            get
            {
                if (_translatorTypes == null)
                {
                    _translatorTypes = new List<Item>();
                    foreach (int item in Enum.GetValues(typeof(TranslatorType.Enum)))
                    {
                        _translatorTypes.Add(new Item(item, Farschidus.Translator.AppTranslate["translatorType.title." + ((TranslatorType.Enum)item).ToString()]));
                    }
                }
                return _translatorTypes;
            }
        }

        private List<Item> _listTypeStyle;
        public List<Item> ListTypeStyle
        {
            get
            {
                if (_listTypeStyle == null)
                {
                    _listTypeStyle = new List<Item>();
                    foreach (int item in Enum.GetValues(typeof(ListTypePage.Enum)))
                    {
                        _listTypeStyle.Add(new Item(item, Farschidus.Translator.AppTranslate["listTypePage.title." + ((ListTypePage.Enum)item).ToString()]));
                    }
                }
                return _listTypeStyle;
            }
        }

        private List<Item> _propertyTypes;
        public List<Item> PropertyTypes
        {
            get
            {
                if (_propertyTypes == null)
                {
                    _propertyTypes = new List<Item>();
                    foreach (int item in Enum.GetValues(typeof(PropertyTypes.Enum)))
                    {
                        _propertyTypes.Add(new Item(item, Farschidus.Translator.AppTranslate["propertyTypes.title." + ((PropertyTypes.Enum)item).ToString()]));
                    }
                }
                return _propertyTypes;
            }
        }

        private List<Item> _propertyItemsValue;
        public List<Item> PropertyItemsValue
        {
            get
            {
                if (_propertyItemsValue == null)
                {
                    _propertyItemsValue = new List<Item>();
                    foreach (int item in Enum.GetValues(typeof(SubjectPropertyValues.Enum)))
                    {
                        _propertyItemsValue.Add(new Item(item, Farschidus.Translator.AppTranslate["PropertyItems." + ((SubjectPropertyValues.Enum)item).ToString()]));
                    }
                }
                return _propertyItemsValue;
            }
        }

        private List<Item> _sexTypes;
        public List<Item> SexTypes
        {
            get
            {
                if (_sexTypes == null)
                {
                    _sexTypes = new List<Item>();

                    foreach (int item in Enum.GetValues(typeof(Sex.Types)))
                    {
                        _sexTypes.Add(new Item(item, Farschidus.Translator.AppTranslate["userManager.default.addEdit." + ((Sex.Types)item).ToString()]));
                    }
                }
                return _sexTypes;
            }
        }

        private List<Item> _gender;
        public List<Item> Gender
        {
            get
            {
                if (_gender == null)
                {
                    _gender = new List<Item>();

                    foreach (int item in Enum.GetValues(typeof(Sex.Types)))
                    {
                        _gender.Add(new Item(item, Farschidus.Translator.AppTranslate["registration.page.default." + ((Sex.Types)item).ToString()]));
                    }
                }
                return _gender;
            }
        }
    }
}