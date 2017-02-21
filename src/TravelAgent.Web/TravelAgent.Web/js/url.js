$.support.cors = true;
var apiURL = (function () {
    //var url = "http://yueyouyuebei.com:8081";
    var url = "http://192.168.1.8:9694";
    return {
        AreaGet: url + "/api/Area/Get",
        AreaGetByPage: url + "/api/Area/GetByPage",
        SchoolGet: url + "/api/School/Get",
        SchoolGetByPage: url + "/api/School/GetByPage",
        SchoolAdd: url + "/api/School/Add",
        SchoolUpload: url + "/api/School/Upload",
        SchoolGetById: url + "/api/School/GetById",
        SchoolUpdate: url + "/api/School/Update",
        ReferencesGet: url + "/api/References/Get",
        ReferencesGetByPage: url + "/api/References/GetByPage",
        ReferencesAdd: url + "/api/References/Add",
        ReferencesUpdate: url + "/api/References/Update",
        ReferencesUpload: url + "/api/References/Upload",
        ReferencesGetBySchoolName: url + "/api/References/GetBySchoolName",
        ReferencesGetById: url + "/api/References/GetById",
        SchoolCodeFile: url + "/api/school/DownSchoolCodeFile",
        SchoolGetByFuzzyName: url + "/api/school/GetBuFuzzyName",

        ReferencesSchoolGetByFuzzy: url + "/api/ReferencesSchool/GetByFuzzy",
        ReferencesSchoolGetBySchId: url + "/api/ReferencesSchool/GetBySchId",
        ReferencesSchoolGetByPage: url + "/api/ReferencesSchool/GetByPage",

        SchoolDel: url + "/api/School/Del",
        ReferencesDel: url + "/api/References/Del",
        SchoolsDelRange: url + "/api/School/DelRange",
        ReferencesDelRange: url + "/api/References/DelRange",

        Login: url + "/Api/Login/Login",
        
        Register: url + "/Api/Register/Register",

        ChangePwd: url + "/Api/User/ChangePwd",
        ChangeName: url + "/Api/User/ChangeName",
        ChangeTel: url + "/Api/User/ChangeTel",
        ChangeEmail: url + "/Api/User/ChangeEmail",
        ChangeGender: url + "/Api/User/ChangeGender",
        GetOrdersByUser: url + "/Api/Order/GetOrdersByUser",
        GetNotPayOrder: url + "/Api/Order/GetNotPayOrder",
        GetOrderDetails: url + "/Api/Order/GetOrderDetails"
    };
})()