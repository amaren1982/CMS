using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UserManagement
{
    public enum Permissions
    {
        None,

        [Description("Manage Roles")]
        ManageRoles = 1,
        AddRole = 2,
        UpdateRole = 3,
        DeleteRole = 4,

        [Description("Manage Users")]
        ManageUsers = 5,
        AddUser = 6,
        UpdateUser = 7,
        DeleteUser = 8,

        [Description("Manage Testimonials")]
        ManageTestimonials = 9,
        AddTestimonial = 10,
        UpdateTestimonial = 11,
        DeleteTestimonial = 12,

        [Description("Manage Downloads")]
        ManageDownloads = 13,
        AddDownload = 14,
        UpdateDownload = 15,
        DeleteDownload = 16,

        [Description("Manage News")]
        ManageNews = 17,
        AddNews = 18,
        UpdateNews = 19,
        DeleteNews = 20,

        [Description("Manage Sectors")]
        ManageSectors = 21,
        AddSector = 22,
        UpdateSector = 23,
        DeleteSector = 24,

        [Description("Manage Qualifications")]
        ManageQualifications = 25,
        AddQualification = 26,
        UpdateQualification = 27,
        DeleteQualification = 28,

        [Description("Manage Photo Gallery")]
        ManagePhotoGallery = 29,
        AddPhotoGallery = 30,
        UpdatePhotoGallery = 31,
        DeletePhotoGallery = 32,

        [Description("Manage Current Openings")]
        ManageCurrentOpenings = 33,
        AddCurrentOpening = 34,
        UpdateCurrentOpening = 35,
        DeleteCurrentOpening = 36,

        [Description("Manage menu")]
        ManageMenus = 37,
        AddMenu = 38,
        UpdateMenu = 39,
        DeleteMenu = 40,

        [Description("Manage pages")]
        ManagePages = 41,
        AddPage = 42,
        UpdatePage = 43,
        DeletePage = 44,

        [Description("Manage Qualifications")]
        ManageCategories = 45,
        AddCategory = 46,
        UpdateCategory = 47,
        DeleteCategory = 48,

        [Description("Manage Qualifications")]
        ManageSubCategories = 49,
        AddSubCategory = 50,
        UpdateSubCategory = 51,
        DeleteSubCategory = 52,
    }
}
