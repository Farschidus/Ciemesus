using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using DAL.DataAccess;

/// <summary>
/// Business Logic Layer Class By Farschidus
/// Generate Date: 7/9/2012 4:10 PM
/// <summary>
namespace BLL.BusinessEntity
{
    public class Gallery
    {
        // It must be sync with SubjectTypes.Enum
        public enum Types
        {
            imageGallery = 4,
            videoGallery,
            audioGallery
        }
    }
}
