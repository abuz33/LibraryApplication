// <-------  Category Operation ---------->
$(document).on("click",
    "#ctgAdd",
    async function () {
        const { value: formValues } = await Swal.fire({
            title: "Add Category",
            html:
                '<input id="ctgName" class="swal2-input">',
        })

        if (formValues) {
            let ctgName = window.$("#ctgName").val();
            window.$.ajax({
                type: "POST",
                url: "/Category/AddJson",
                data: { 'ctgName': ctgName },
                dataType: "Json",
                success: function (data) {
                    var ctgId = data.Result.Id;
                    var ctgName = `<td>${data.Result.Name}</td>`;
                    var ctgBookNumber = "<td>0 </td>";
                    var updateCtg =
                        `'<td><a class='update btn btn-facebook' value='${ctgId}'>Update</a> </td>'`;
                    var deleteCtg = `'<td><a class='delete btn btn-danger' value='${ctgId}>Delete</a> </td>`;

                    window.$("#example tbody").prepend("<tr>" +
                        ctgName +
                        ctgBookNumber +
                        updateCtg +
                        deleteCtg +
                        "</tr>");
                    Swal.fire({
                        type: "success",
                        title: " Category Added",
                        text: "Operation has been done successfully."
                    });
                },
                error: function () {
                    Swal.fire({
                        type: "error",
                        title: " Category Not Added",
                        text: "There was an error."
                    });
                }
            });
        }
    });
$(document).on("click", ".update", async function () {
    var ctgId = this.attributes.value.value;
    var ctgNameTd = window.$(this).parent("td").parent("tr").find("td:first");
    var ctgName = ctgNameTd.html();

    const { value: formValues } = await Swal.fire({
        title: "Update Category",
        html:
            `<input id="ctgName" value="${ctgName}" class="swal2-input">`,
    });

    ctgName = window.$("#ctgName").val();

    window.$.ajax({
        type: "POST",
        url: "/Category/UpdateJson",
        data: {
            'ctgId': ctgId,
            'ctgName': ctgName
        },
        dataType: "Json",
        success: function (data) {
            if (data === "1") {
                ctgNameTd.html(ctgName);
                Swal.fire({
                    type: "success",
                    title: " Category Updated",
                    text: "Operation has been done successfully."
                });
            } else {
                Swal.fire({
                    type: "error",
                    title: " Category Not Updated",
                    text: "An Error Has Happened."
                });
            }
        },
        error: function () {
            Swal.fire({
                type: "error",
                title: " Category Not Updated",
                text: "There was an error."
            });
        }
    });
});
$(document).on("click", ".delete", async function () {
    var ctgId = this.attributes.value.value;
    var tr = $(this).parent("td").parent("tr");
    window.$.ajax({
        type: "POST",
        url: "/Category/DeleteJson",
        data: {
            'ctgId': ctgId
        },
        dataType: "Json",
        success: function (data) {
            if (data === "1") {
                tr.remove();
                Swal.fire({
                    type: "success",
                    title: " Category Deleted",
                    text: "Operation has been done successfully."
                });
            } else {
                Swal.fire({
                    type: "error",
                    title: " Category Not Deleted",
                    text: "An Error Has Happened."
                });
            }
        },
        error: function () {
            Swal.fire({
                type: "error",
                title: " Category Not Deleted",
                text: "There was an error."
            });
        }
    });
});
// <------- Category Operation END ------->

// <-------  Writer Operation ---------->
$(document).on("click",
    "#wrtAdd",
    async function () {
        const { value: formValues } = await Swal.fire({
            title: "Add Writer",
            html:
                '<input id="wrtName" class="swal2-input">',
        })

        if (formValues) {
            let wrtName = window.$("#wrtName").val();
            window.$.ajax({
                type: "POST",
                url: "/Writer/AddJson",
                data: { 'wrtName': wrtName },
                dataType: "Json",
                success: function (data) {
                    var wrtId = data.Result.Id;
                    var wrtName = `<td>${data.Result.Name}</td>`;
                    var wrtBookNumber = "<td>0 </td>";
                    var updateWrt = `'<td><a class='updateWrt btn btn-facebook' value='${wrtId}'>Update</a> </td>'`;
                    var deleteWrt = `'<td><a class='deleteWrt btn btn-danger' value='${wrtId}>Delete</a> </td>`;

                    window.$("#example tbody").prepend("<tr>" +
                        wrtName +
                        wrtBookNumber +
                        updateWrt +
                        deleteWrt +
                        "</tr>");
                    Swal.fire({
                        type: "success",
                        title: " Writer Added",
                        text: "Operation has been done successfully."
                    });
                },
                error: function () {
                    Swal.fire({
                        type: "error",
                        title: " Writer Not Added",
                        text: "There was an error."
                    });
                }
            });
        }
    });
$(document).on("click", ".updateWrt", async function () {
    var wrtId = this.attributes.value.value;
    var wrtNameTd = window.$(this).parent("td").parent("tr").find("td:first");
    var wrtName = wrtNameTd.html();

    const { value: formValues } = await Swal.fire({
        title: "Update Writer",
        html:
            `<input id="wrtName" value="${wrtName}" class="swal2-input">`,
    });

    wrtName = window.$("#wrtName").val();

    window.$.ajax({
        type: "POST",
        url: "/Writer/UpdateJson",
        data: {
            'wrtId': wrtId,
            'wrtName': wrtName
        },
        dataType: "Json",
        success: function (data) {
            if (data === "1") {
                wrtNameTd.html(wrtName);
                Swal.fire({
                    type: "success",
                    title: " Writer Updated",
                    text: "Operation has been done successfully."
                });
            } else {
                Swal.fire({
                    type: "error",
                    title: " Writer Not Updated",
                    text: "An Error Has Happened."
                });
            }
        },
        error: function () {
            Swal.fire({
                type: "error",
                title: " Writer Not Updated",
                text: "There was an error."
            });
        }
    });
});
$(document).on("click", ".deleteWrt", async function () {
    var wrtId = this.attributes.value.value;
    var tr = $(this).parent("td").parent("tr");
    window.$.ajax({
        type: "POST",
        url: "/Writer/DeleteJson",
        data: {
            'wrtId': wrtId
        },
        dataType: "Json",
        success: function (data) {
            if (data === "1") {
                tr.remove();
                Swal.fire({
                    type: "success",
                    title: " Writer Deleted",
                    text: "Operation has been done successfully."
                });
            } else {
                Swal.fire({
                    type: "error",
                    title: " Writer Not Deleted",
                    text: "An Error Has Happened."
                });
            }
        },
        error: function () {
            Swal.fire({
                type: "error",
                title: " Writer Not Deleted",
                text: "There was an error."
            });
        }
    });
});
// <------- Writer Operation END ------->


// <-------  Book Operation ---------->
$(document).on("click", ".addCat", async function () {
    var selectedCategoryName = $("#categories").val();
    if (selectedCategoryName != null && selectedCategoryName != "") {
        var selectedCategoryId = $("#categories option:selected").attr("data-id");
        $("#addedCategories")
            .append(
                `<div id="${selectedCategoryId} " class="deleteCategory col-md-1 bg-primary" style="margin-right:2px; margin-bottom:2px; ">
                ${selectedCategoryName} <i class="fa fa-times"></i>
            </div> `);
        $("#categories option:selected").remove();
    }
});
$(document).on("click", ".deleteCategory", async function () {
    var id = this.attributes[0].value;
    var categoryName = $(this).html();
    $("#categories").append(`<option data-id="${id}">${categoryName}</option>`);
    $(this).remove();
});
$(document).on("click", "#addBook", async function () {
    let categories = [];

    $("#addedCategories div").each(function () {
        if ($(this).attr("id")) {
            var id = $(this).attr("id");
            categories.push(id);
        }
    });

    $.ajax({
        type: "Post",
        url: "/Book/AddBookJson",
        data: {
            'categories': categories,
            'writer': $("#writer option:selected").attr("data-id"),
            'bookName': $("#bookName").val(),
            'bookQuantity': $("#bookQuantity").val(),
            'orderNumber': $("#orderNumber").val(),
        },
        dataType: "JSON",
        contentTpe: "application/json; charset=utf-8",
        success: function (receivedValue) {
            if (receivedValue) {
                Swal.fire({
                    type: "success",
                    title: "Book Added",
                    text: "Operation has been successfully Added."
                });
            } else if ("cannot be empty") {
                Swal.fire({
                    type: "success",
                    title: "Book Not Added",
                    text: "Do not leave any empty input. Fill them Please."
                });
            }
        },
        error: function () {
            Swal.fire({
                type: "error",
                title: "Book Not Added",
                text: "There was an error."
            });
        }
    });
});

$(document).on("click", ".deleteBook", async function () {
    Swal.fire({
        title: "Deleting!!!",
        text: "Do you want to delete the book permanently?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.value) {
            var bookId = $(this).attr("value");
            var tr = window.$(this).parent().parent();
            $.ajax({
                type: "Post",
                url: "/Book/DeleteJson",
                data: { "bookId": bookId },
                dataType: "Json",
                success: function (data) {
                    if (data === "1") {
                        tr.remove();
                        Swal.fire({
                            type: "success",
                            title: "Book Deleted!",
                            text: "Your file has been deleted."
                        });

                    } else {
                        Swal.fire({
                            type: "error",
                            title: "Book Not Deleted!",
                            text: "There was an error in database."
                        });
                    }
                },
                error: function () {
                    Swal.fire({
                        type: "error",
                        title: "Book Not Deleted!",
                        text: "There was an error."
                    });
                }
            });

        }
    });
});

$(document).on("click", "#updateBook", async function () {
    var bookId = $(this).attr("data-id");
    let categories = [];

    $("#addedCategories div").each(function () {
        if ($(this).attr("id")) {
            var id = $(this).attr("id");
            categories.push(id);
        }
    });

    $.ajax({
        type: 'Post',
        url: "/Book/UpdateBookJson",
        data: {
            "bookId": bookId,
            'categories': categories,
            'writer': $("#writer option:selected").attr("data-id"),
            'bookName': $("#bookName").val(),
            'bookQuantity': $("#bookQuantity").val(),
            'orderNumber': $("#orderNumber").val(),
        },
        dataType: "JSON",
        contentTpe: "application/json; charset=utf-8",
        success: function (receivedValue) {
            if (receivedValue) {
                Swal.fire({
                    type: "success",
                    title: "Book Updated",
                    text: "Operation has been successfully Added."
                });
            } else if ("cannot be empty") {
                Swal.fire({
                    type: "success",
                    title: "Book Not Updated",
                    text: "Do not leave any empty input. Fill them Please."
                });
            }
        },
        error: function () {
            Swal.fire({
                type: "error",
                title: "Book Not Added",
                text: "There was an error."
            });
        }
    });
});

// <------- Book Operation END ------->

// <-------  Member Operation ---------->
$(document).on("click", "#addMember", async function () {
    $.ajax({
        type: "Post",
        url: "/Member/AddMemberJson",
        data: {
            'name': $("#memberName").val(),
            'lastname': $("#memberLastname").val(),
            'identityNumber': $("#identity").val(),
            'phone': $("#phone").val(),
        },
        dataType: "JSON",
        contentTpe: "application/json; charset=utf-8",
        success: function (receivedValue) {
            if (receivedValue) {
                Swal.fire({
                    type: "success",
                    title: "Member Added",
                    text: "Operation has been successfully Added."
                });
            } else if (receivedValue == "cannot be empty") {
                Swal.fire({
                    type: "error",
                    title: "Member Not Added",
                    text: "Name and Lastname cannot be empty. Fill them Please."
                });
            }
        },
        error: function () {
            Swal.fire({
                type: "error",
                title: "Member Not Added",
                text: "There was an error."
            });
        }
    });
});
$(document).on("click", ".deleteMember", async function () {
    Swal.fire({
        title: "Deleting!!!",
        text: "Do you want to delete the book permanently?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.value) {
            var memberId = $(this).attr("value");
            var tr = window.$(this).parent().parent();
            $.ajax({
                type: "Post",
                url: "/Member/DeleteMemberJson",
                data: { "memberId": memberId },
                dataType: "Json",
                success: function (data) {
                    if (data === "1") {
                        tr.remove();
                        Swal.fire({
                            type: "success",
                            title: "Member Deleted!",
                            text: "Your file has been deleted."
                        });

                    } else {
                        Swal.fire({
                            type: "error",
                            title: "Member Not Deleted!",
                            text: "There was an error in database."
                        });
                    }
                },
                error: function () {
                    Swal.fire({
                        type: "error",
                        title: "Member Not Deleted!",
                        text: "There was an error."
                    });
                }
            });

        }
    });
});
$(document).on("click", "#updateMember", async function () {
    $.ajax({
        type: "Post",
        url: "/Member/UpdateMemberJson",
        data: {
            'name': $("#memberName").val(),
            'lastname': $("#memberLastname").val(),
            'identityNumber': $("#identity").val(),
            'phone': $("#phone").val(),
            'memberId': $(this).attr('data-id')
        },
        dataType: "JSON",
        contentTpe: "application/json; charset=utf-8",
        success: function (receivedValue) {
            if (receivedValue) {
                Swal.fire({
                    type: "success",
                    title: "Member Added",
                    text: "Operation has been successfully Added."
                });
            } else if (receivedValue == "cannot be empty") {
                Swal.fire({
                    type: "error",
                    title: "Member Not Added",
                    text: "Name and Lastname cannot be empty. Fill them Please."
                });
            }
        },
        error: function () {
            Swal.fire({
                type: "error",
                title: "Member Not Added",
                text: "There was an error."
            });
        }
    });
});
// <------- Member Operation END ------->
