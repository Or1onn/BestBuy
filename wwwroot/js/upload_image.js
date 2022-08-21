//Dropzone.options.imageForm = { // camelized version of the `id`
//    paramName: "file",
//    url: "https://localhost:7195/Home/SaveUploadedFile",
//    autoProcessQueue: false,
//    uploadMultiple: false,
//    autoDiscover: false,
//    parallelUploads: 100,
//    maxFiles: 100,
//    addRemoveLinks: true,
//    acceptedFiles: "image/*",
//    // The setting up of the dropzone
//    init: function () {
//        var myDropzone = this;
//    }
//};

var e = "#addForm",
var t = new Dropzone(e, {
    maxFilesize: 1,
    acceptedFiles: ".png,.jpg,.jpeg",
    uploadMultiple: false,
    autoProcessQueue: false
});
t.on("addedfile", function (o) {
    $("#Files").files = t.hiddenFileInput.files;
})