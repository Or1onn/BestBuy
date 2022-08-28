Dropzone.options.imageForm = { // camelized version of the `id`
    paramName: "file",
    maxFilesize: 20,
    maxFiles: 4,
    acceptedFiles: "image/*",
    dictMaxFilesExceeded: "Custom max files msg",
    accept: function (file, done) {
        if (file.name == "justinbieber.jpg") {
            done("Naha, you don't.");
        }
        else { done(); }
    }
};
