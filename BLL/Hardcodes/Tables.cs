using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessEntity;

namespace BLL.Hardcodes
{
    public class Tables
    {
        private List<Hardcodes.Item> _headerTypes;
        public List<Hardcodes.Item> HeaderTypes
        {
            get
            {
                if (_headerTypes == null)
                {
                    _headerTypes = new List<Hardcodes.Item>();

                    foreach (int item in Enum.GetValues(typeof(Subjects.BannerTypes)))
                    {
                        _headerTypes.Add(new Hardcodes.Item(item, Farschidus.Translator.AppTranslate["headerTypes.title." + ((Subjects.BannerTypes)item).ToString()]));
                    }
                }
                return _headerTypes;
            }
        }

        private List<Hardcodes.Item> _galleryTypes;
        public List<Hardcodes.Item> GalleryTypes
        {
            get
            {
                if (_galleryTypes == null)
                {
                    _galleryTypes = new List<Hardcodes.Item>();

                    foreach (int item in Enum.GetValues(typeof(Gallery.Types)))
                    {
                        _galleryTypes.Add(new Hardcodes.Item(item, Farschidus.Translator.AppTranslate["galleryTypes.title." + ((Gallery.Types)item).ToString()]));
                    }
                }
                return _galleryTypes;
            }
        }

        private List<Hardcodes.Item> _subjectTypes;
        public List<Hardcodes.Item> SubjectTypes
        {
            get
            {
                if (_subjectTypes == null)
                {
                    _subjectTypes = new List<Hardcodes.Item>();
                    foreach (int item in Enum.GetValues(typeof(SubjectTypes.Enum)))
                    {
                        _subjectTypes.Add(new Hardcodes.Item(item, Farschidus.Translator.AppTranslate["subjectTypes.title." + ((SubjectTypes.Enum)item).ToString()]));
                    }
                }
                return _subjectTypes;
            }
        }

        private List<Hardcodes.Item> _mediaSubjectTypes;
        public List<Hardcodes.Item> MediaSubjectTypes
        {
            get
            {
                if (_mediaSubjectTypes == null)
                {
                    _mediaSubjectTypes = new List<Hardcodes.Item>();
                    foreach (int item in Enum.GetValues(typeof(MediaSubjectTypes.Enum)))
                    {
                        _mediaSubjectTypes.Add(new Hardcodes.Item(item, Farschidus.Translator.AppTranslate["mediaSubjectTypes.title." + ((MediaSubjectTypes.Enum)item).ToString()]));
                    }
                }
                return _mediaSubjectTypes;
            }
        }

        private List<Hardcodes.Item> _translatorTypes;
        public List<Hardcodes.Item> TranslatorTypes
        {
            get
            {
                if (_translatorTypes == null)
                {
                    _translatorTypes = new List<Hardcodes.Item>();
                    foreach (int item in Enum.GetValues(typeof(TranslatorType.Enum)))
                    {
                        _translatorTypes.Add(new Hardcodes.Item(item, Farschidus.Translator.AppTranslate["translatorType.title." + ((TranslatorType.Enum)item).ToString()]));
                    }
                }
                return _translatorTypes;
            }
        }

        private List<Hardcodes.Item> _listTypePage;
        public List<Hardcodes.Item> ListTypePage
        {
            get
            {
                if (_listTypePage == null)
                {
                    _listTypePage = new List<Hardcodes.Item>();
                    foreach (int item in Enum.GetValues(typeof(ListTypePage.Enum)))
                    {
                        _listTypePage.Add(new Hardcodes.Item(item, Farschidus.Translator.AppTranslate["listTypePage.title." + ((ListTypePage.Enum)item).ToString()]));
                    }
                }
                return _listTypePage;
            }
        }

        private List<Hardcodes.Item> _propertyTypes;
        public List<Hardcodes.Item> PropertyTypes
        {
            get
            {
                if (_propertyTypes == null)
                {
                    _propertyTypes = new List<Hardcodes.Item>();
                    foreach (int item in Enum.GetValues(typeof(PropertyTypes.Enum)))
                    {
                        _propertyTypes.Add(new Hardcodes.Item(item, Farschidus.Translator.AppTranslate["propertyTypes.title." + ((PropertyTypes.Enum)item).ToString()]));
                    }
                }
                return _propertyTypes;
            }
        }

        private List<Hardcodes.Item> _propertyItemsValue;
        public List<Hardcodes.Item> PropertyItemsValue
        {
            get
            {
                if (_propertyItemsValue == null)
                {
                    _propertyItemsValue = new List<Hardcodes.Item>();
                    foreach (int item in Enum.GetValues(typeof(SubjectPropertyValues.Enum)))
                    {
                        _propertyItemsValue.Add(new Hardcodes.Item(item, Farschidus.Translator.AppTranslate["PropertyItems." + ((SubjectPropertyValues.Enum)item).ToString()]));
                    }
                }
                return _propertyItemsValue;
            }
        }

        private List<Hardcodes.Item> _sexTypes;
        public List<Hardcodes.Item> SexTypes
        {
            get
            {
                if (_sexTypes == null)
                {
                    _sexTypes = new List<Hardcodes.Item>();

                    foreach (int item in Enum.GetValues(typeof(Sex.Types)))
                    {
                        _sexTypes.Add(new Hardcodes.Item(item, Farschidus.Translator.AppTranslate["userManager.default.addEdit." + ((Sex.Types)item).ToString()]));
                    }
                }
                return _sexTypes;
            }
        }

        private List<Hardcodes.Item> _gender;
        public List<Hardcodes.Item> Gender
        {
            get
            {
                if (_gender == null)
                {
                    _gender = new List<Hardcodes.Item>();

                    foreach (int item in Enum.GetValues(typeof(Sex.Types)))
                    {
                        _gender.Add(new Hardcodes.Item(item, Farschidus.Translator.AppTranslate["registration.page.default." + ((Sex.Types)item).ToString()]));
                    }
                }
                return _gender;
            }
        }
    }
}