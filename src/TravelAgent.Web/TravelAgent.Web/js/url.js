$.support.cors = true;
var apiURL = (function () {
    var url = "http://192.168.1.3:9694"
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
        ReferencesGetById: url + "/api/References/GetById"
    };
})()