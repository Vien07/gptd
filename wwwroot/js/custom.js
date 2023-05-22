function ToastifyAlert(mess, type) {
    var backgroundColor = "linear-gradient(to right, #00b09b, #96c93d)";
    if (type == "error") {
        backgroundColor = "linear-gradient(#e66465, #9198e5)";
    }
    Toastify({
        text: mess,
        duration: 3000,
        backgroundColor: backgroundColor,
    }).showToast();
}
//search
function Search() {
    let searchVal = encodeURI($("#_search").val()).replaceAll('%20', '-');
    location.href = `/tim-kiem/${searchVal}/`
}
$('input#_search').on('keyup', function (e) {
    e.preventDefault();
    if (e.keyCode == 13) {
        Search()
    }
})
//contact
function SendContact(frmId, thisButton) {
    var validate = $("#" + frmId).parsley().validate();
    if (validate) {
        var formdata = new FormData($("#" + frmId)[0]);
        $.ajax({
            type: "POST",
            url: "/Contact/Send",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
                $(thisButton).attr('disabled', 'disabled')
            },
            data: formdata,
            enctype: 'multipart/form-data',
            processData: false,
            contentType: false,
            success: function (data) {
                if (!data.response.isError) {
                    toastr.success('Liên hệ thành công! Chúng tôi sẽ gửi bạn câu trả lời sớm nhất có thể!!!', 'Thông báo')
                    $("#" + frmId)[0].reset();

                    setTimeout(function () {
                        location.href = '/'
                    }, 3000)
                } else {
                    toastr.error('Có lỗi xảy ra trong quá trình liên hệ vui lòng báo với chúng tôi qua các kênh liên hệ!!!', 'Thông báo')
                }
                $(thisButton).removeAttr('disabled');
            },
            failure: function (response) {
                $(thisButton).removeAttr('disabled');
            }
        });
    }
}

//cart
loadCart();

function loadCart() {
    try {
        $.ajax({
            type: "GET",
            url: "/Home/LoadCart",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            data: { data: localStorage.getItem('cart') },
            success: function (data) {
                if (!data.response.isError) {
                    $('.totalQuantity').text(data.response.data.totalQuantity);
                    loadFormCart(data);
                    loadFormOrder(data);
                } else {
                    localStorage.setItem('cart', JSON.stringify([]))
                }
            },
            failure: function (response) {
            }
        });
    } catch (e) {
        localStorage.setItem('cart', JSON.stringify([]))
        toastr.error('Có lỗi xảy ra trong quá trình thêm vào giỏ hàng vui lòng báo với chúng tôi qua các kênh liên hệ!!!', 'Thông báo')
        console.error(e);
    }
}
function loadFormCart(data) {
    $('.totalPrice').html(`${data.response.data.totalPriceString}<sup><u>đ</u></sup>`);
    let items = data.response.data.items;
    let html = ``;
    for (var item of items) {
        html += ` <div class="cart-items">
                    <div class="cart-info">
                        <div class="thumb">
                            <img src="${item.image}" />
                        </div>
                        <div class="name-products">
                            <div class="tt fw-normal">
                                ${item.title}
                            </div>
                            <a class="txt-price" alt="Xoá"  onclick="deleteItem(${item.productId})" title="Xoá">Xoá</a>
                        </div>
                    </div>
                    <div class="cart-quanlity">
                        <div class="d-lg-none">Số lượng:</div>
                        <div class="form-quantity">
                            <input class="form-control" type="text" value="${item.quantity}" />
                            <a class="control-down fa fa-minus" onclick="down(${item.productId})" role="button"></a>
                            <a class="control-up fa fa-plus"  onclick="up(${item.productId})" role="button"></a>
                        </div>
                    </div>
                    <div class="cart-unit-price">
                        <div class="d-lg-none">Đơn giá:</div>
                        <div class="price txt-price">
                            ${item.priceString}<sup><u>đ</u></sup>
                        </div>
                    </div>
                    <div class="cart-total-price">
                        <div class="d-lg-none">Thành tiền:</div>
                        <div class="price txt-price">
                            ${item.totalPriceString}<sup><u>đ</u></sup>
                        </div>
                    </div>
                </div>`;
    }

    $('.items_a').html(html);
}
function loadFormOrder(data) {
    $('.totalPrice').html(`${data.response.data.totalPriceString}<sup><u>đ</u></sup>`);
    let items = data.response.data.items;
    let html = ``;
    for (var item of items) {
        html += `<div class="order-item">
                                <div class="order-thumb">
                                    <div class="thumb-res square mb-0">
                                        <img src="${item.image}">
                                    </div>
                                </div>
                                <div class="order-info">
                                    <div class="tt fw-normal">${item.title}</div>
                                    <div class="price txt-price">
                                         ${item.priceString}<sup><u>đ</u></sup>
                                    </div>
                                </div>
                                <div class="order-count">
                                    <span class="quantity">${item.quantity}</span>
                                </div>
                            </div>`;
    }

    $('.items_b').html(html);
}
function addToCart(pid) {
    try {
        quantity = 1;
        var cart = JSON.parse(localStorage.getItem('cart'));
        if (cart) {
            let flag = false;
            for (let item of cart) {
                if (item.productId == pid) {
                    item.quantity += quantity;
                    flag = true;
                }
            }

            if (!flag) {
                cart.push({ productId: pid, quantity: quantity })
            }

            localStorage.setItem('cart', JSON.stringify(cart))

        } else {
            cart = [];
            cart.push({ productId: pid, quantity: quantity })
            localStorage.setItem('cart', JSON.stringify(cart))
        }

        toastr.success('Thêm vào giỏ hàng thành công!!!', 'Thông báo')
        loadCart();

    } catch (e) {
        localStorage.setItem('cart', JSON.stringify([]))
        toastr.error('Có lỗi xảy ra trong quá trình thêm vào giỏ hàng vui lòng báo với chúng tôi qua các kênh liên hệ!!!', 'Thông báo')
        console.error(e);
    }
}
function up(pid) {
    try {
        var cart = JSON.parse(localStorage.getItem('cart'));
        for (let item of cart) {
            if (item.productId == pid) {
                item.quantity += 1;
            }
        }
        localStorage.setItem('cart', JSON.stringify(cart));

        loadCart();
    } catch (e) {
        localStorage.setItem('cart', JSON.stringify([]))
        toastr.error('Có lỗi xảy ra trong quá trình thêm vào giỏ hàng vui lòng báo với chúng tôi qua các kênh liên hệ!!!', 'Thông báo')
        console.error(e);
    }
}
function down(pid) {
    try {
        var cart = JSON.parse(localStorage.getItem('cart'));
        for (let item of cart) {
            if (item.productId == pid) {
                if (item.quantity > 1) {
                    item.quantity -= 1;
                }
            }
        }
        localStorage.setItem('cart', JSON.stringify(cart));

        loadCart();
    } catch (e) {
        localStorage.setItem('cart', JSON.stringify([]))
        toastr.error('Có lỗi xảy ra trong quá trình thêm vào giỏ hàng vui lòng báo với chúng tôi qua các kênh liên hệ!!!', 'Thông báo')
        console.error(e);
    }
}
function deleteItem(pid) {
    try {
        var cart = JSON.parse(localStorage.getItem('cart'));
        cart = cart.filter(x => x.productId != pid);
        toastr.success('Xóa khỏi giỏ hàng thành công!!!', 'Thông báo')

        localStorage.setItem('cart', JSON.stringify(cart));
        loadCart();
    } catch (e) {
        localStorage.setItem('cart', JSON.stringify([]))
        toastr.error('Có lỗi xảy ra trong quá trình thêm vào giỏ hàng vui lòng báo với chúng tôi qua các kênh liên hệ!!!', 'Thông báo')
        console.error(e);
    }
}
function saveOrder(frmId, thisButton) {
    let cart = JSON.parse(localStorage.getItem("cart"));
    if (!cart || cart.length <= 0) {
        toastr.warning('Không có sản phẩm trong giỏ hàng!', 'Thông báo')
        return;
    }

    var validate = $("#" + frmId).parsley().validate();
    if (validate) {
        var formdata = new FormData($("#" + frmId)[0]);
        formdata.append('Address', $('#Address').val() + ", " + $('#Ward option:selected').text() + ", " + $('#District option:selected').text() + ", " + $('#City option:selected').text())
        formdata.append('Cart', localStorage.getItem('cart'))
        $.ajax({
            type: "POST",
            url: "/Home/SaveOrder",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
                $(thisButton).addClass('disabled')
            },
            data: formdata,
            enctype: 'multipart/form-data',
            processData: false,
            contentType: false,
            success: function (data) {
                if (!data.response.isError) {
                    toastr.success('Đặt hàng thành công!!!', 'Thông báo')
                    $("#" + frmId)[0].reset();
                    localStorage.setItem('cart', JSON.stringify([]))
                    setTimeout(function () {
                        location.href = '/'
                    }, 5000)
                } else {
                    toastr.error('Có lỗi xảy ra trong quá trình đặt hàng vui lòng báo với chúng tôi qua các kênh liên hệ!!!', 'Thông báo')
                }
                $(thisButton).removeClass('disabled');
            },
            failure: function (response) {
                $(thisButton).removeClass('disabled');
            }
        });
    }
}
function getSelectProvince(divProvinceId, divDistrictId, divWardId) {
    $.ajax({
        url: '/data/VietNam/province.json',
        method: 'GET',
        success: function (data) {
            let rs = [];

            Object.keys(data).forEach((i) => {
                rs.push(data[i])
            });

            rs = rs.sort(function (a, b) {
                return ('' + a.name_with_type).localeCompare(b.name_with_type);
            });

            data = {};

            for (let i in rs) {
                data[i] = rs[i]
            }


            let html = ``;
            Object.keys(data).forEach((i) => {
                html += `<option value="${data[i].code}">${data[i].name_with_type}</option>`
            });

            $('#' + divProvinceId).html(html);

            $('#' + divProvinceId).change((e) => {
                let code = e.target.value;
                $.ajax({
                    url: `/data/VietNam/district/${code}.json`,
                    method: 'GET',
                    success: function (data) {
                        let html = ``;
                        Object.keys(data).forEach((i) => {
                            html += `<option value="${data[i].code}">${data[i].name_with_type}</option>`
                        });

                        $('#' + divDistrictId).html(html);

                        $('#' + divDistrictId).change((e) => {
                            let code = e.target.value;
                            $.ajax({
                                url: `/data/VietNam/ward/${code}.json`,
                                method: 'GET',
                                success: function (data) {
                                    let html = ``;
                                    Object.keys(data).forEach((i) => {
                                        html += `<option value="${data[i].code}">${data[i].name_with_type}</option>`
                                    });

                                    $('#' + divWardId).html(html);
                                },
                                error: function (err) {
                                    console.log(err)
                                }
                            })

                        })

                        $('#' + divDistrictId).trigger('change');

                    },
                    error: function (err) {
                        console.log(err)
                    }
                })
            })

            $('#' + divProvinceId).trigger('change');

        },
        error: function (err) {
            console.log(err)
        }
    })
}