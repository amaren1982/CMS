using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceInterface;

namespace Techkriti.Common.Proxy
{
    public class ProxyFactory
    {
        public static UserManagementClient CreateUserManagementProxy() { return new UserManagementClient(); }

        public static NewsManagementClient CreateNewsManagementProxy() { return new NewsManagementClient(); }

        public static CurrentOpeningsManagementClient CreateCurrentOpeningManagementProxy() { return new CurrentOpeningsManagementClient();  }

        public static SectorsManagementClient CreateSectorsManagementProxy() { return new SectorsManagementClient(); }

        public static TestimonialsManagementClient CreateTestimonialsManagementProxy() { return new TestimonialsManagementClient(); }

        public static PhotoGalleryManagementClient CreatePhotoGalleryManagementProxy() { return new PhotoGalleryManagementClient(); }

        public static DownloadsManagementClient CreateDownloadsManagementProxy() { return new DownloadsManagementClient(); }

        public static QualificationsManagementClient CreateQualificationsManagementProxy() { return new QualificationsManagementClient(); }

        public static ContentManagementClient CreateContentManagementProxy() { return new ContentManagementClient(); }
    }

    public class UserManagementClient : ServiceProxy<IUserManagement> 
    {
        public UserManagementClient() 
            : base("WSHttpBinding_IUserManagement") { } 
    }

    public class NewsManagementClient : ServiceProxy<INewsManagement> 
    { 
        public NewsManagementClient() 
            : base("WSHttpBinding_INewsManagement") { } 
    }

    public class CurrentOpeningsManagementClient : ServiceProxy<ICurrentOpeningsManagement>  
    { 
        public CurrentOpeningsManagementClient() 
            : base("WSHttpBinding_ICurrentOpeningsManagement") { } 
    }

    public class SectorsManagementClient : ServiceProxy<ISectorsManagement> 
    { 
        public SectorsManagementClient() 
            : base("WSHttpBinding_ISectorsManagement") { } 
    }

    public class TestimonialsManagementClient : ServiceProxy<ITestimonialManagement> 
    {
        public TestimonialsManagementClient()
            : base("WSHttpBinding_ITestimonialManagement") 
        { } 
    }

    public class PhotoGalleryManagementClient : ServiceProxy<IPhotoGalleryManagement>
    {
        public PhotoGalleryManagementClient()
            : base("WSHttpBinding_IPhotoGalleryManagement")
        { }
    }

    public class DownloadsManagementClient : ServiceProxy<IDownloadsManagement>
    {
        public DownloadsManagementClient()
            : base("WSHttpBinding_IDownloadsManagement")
        { }
    }

    public class QualificationsManagementClient : ServiceProxy<IQualificationsManagement>
    {
        public QualificationsManagementClient()
            : base("WSHttpBinding_IQualificationsManagement")
        { }
    }

    public class ContentManagementClient : ServiceProxy<IContentManagement>
    {
        public ContentManagementClient()
            : base("WSHttpBinding_IContentManagement")
        { }
    }
   
}