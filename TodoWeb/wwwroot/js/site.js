// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const { data } = require("jquery");



// Write your JavaScript code.
//firstChild.wholeText
//function handleChange(checkbox) {
//    var tableRow = checkbox.parents().eq(2);
//    var id = tableRow.children
//}
function handleChange(checkbox) {
    var tableRow = checkbox.parentElement.parentElement;
    var id = tableRow.children[0].innerHTML;
    var id_trim = id.trim();
    var status = checkbox.checked

    if (status) {
        tableRow.classList.remove("table-light");
        tableRow.classList.add("table-success");
        
    }
    else {
        tableRow.classList.remove("table-success");
        tableRow.classList.add("table-light");

        
    }
    Is_complete(id_trim, status);
    
};


//window.onload = function(){

//}
//functon Is_complete(id, status){
//    $.ajax({
//        type: "POST",
//        url: "/User/ToDoList/AjaxMethod/",
//        data: { id, status },
//        success: function (data) {
//            if (data == "Completed") {
//                tableRow.toggleClass("table-success");
//            }
//        }
//    });
//};
function Is_complete(id, status) {
    var xhr = new XMLHttpRequest();
    var ajaxPath = "/User/ToDoList/AjaxMethod";
    xhr.open("POST", ajaxPath,false);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify({ id, status }));
};


    