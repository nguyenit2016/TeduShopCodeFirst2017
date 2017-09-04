var cart = {
    init: function () {
        cart.loadData();
        cart.registerEvent();
    },
    registerEvent: function () {
        $("#frmPayment").validate({
            rules: {
                name: "required",
                address: "required",
                email: {
                    email: true,
                    required: true
                },
                phone: {
                    required: true,
                    number: true
                }
            },
            messages: {
                name: "Vui lòng nhập tên",
                address: "Vui lòng nhập địa chỉ",
                email: {
                    email: "Định dạng email chưa đúng",
                    required: "Vui lòng nhập email"
                },
                phone: {
                    required: "Vui lòng nhập số điện thoại",
                    number: "Số điện thoại phải là số"
                }
            }
        });
        $(".btnDeleteItem").off('click').on('click', function (e) {
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            cart.deleteItem(productId);
        });
        $(".tbQuantity").off('keyup').on('keyup', function () {
            var quantity = parseInt($(this).val());
            if (isNaN(quantity) == false) {
                var productId = parseInt($(this).data('id'));
                var price = parseFloat($(this).data('price'));
                var amount = quantity * price;
                $("#amount_" + productId).text(numeral(amount).format('0,0'));
            }
            else {
                $("#amount_" + productId).text(0);
            }
            $("#lblTotalOrder").text(numeral(cart.getTotalOrder()).format('0,0'));
            cart.updateAll();
        });
        $(".tbQuantity").off('change').on('change', function () {
            var quantity = parseInt($(this).val());
            if (isNaN(quantity) == false) {
                var productId = parseInt($(this).data('id'));
                var price = parseFloat($(this).data('price'));
                var amount = quantity * price;
                $("#amount_" + productId).text(numeral(amount).format('0,0'));
            }
            else {
                $("#amount_" + productId).text(0);
            }
            $("#lblTotalOrder").text(numeral(cart.getTotalOrder()).format('0,0'));
            cart.updateAll();
        });
        $("#CartContinue").off('click').on('click', function (e) {
            e.preventDefault();
            window.location.href = "/";
        });
        $("#CartDeleteAll").off('click').on('click', function (e) {
            e.preventDefault();
            cart.deleteAll();
        });
        $("#CartPayment").off('click').on('click', function (e) {
            e.preventDefault();
            window.location.href = "/thanh-toan.html";
        });
        $("#CartCheckout").off('click').on('click', function (e) {
            e.preventDefault();
            $("#divCheckout").show();
        });
        $("#checkUserLogin").off('click').on('click', function () {
            if ($(this).prop('checked')) {
                cart.getLoginUser();
            }
            else {
                $("#txtName").val('');
                $("#txtAddress").val('');
                $("#txtEmail").val('');
                $("#txtPhone").val('');
            }
        });
        $("#btnCreateOrder").off('click').on('click', function (e) {
            e.preventDefault();
            var isValid = $("#frmPayment").valid();
            if (isValid) {
                cart.createOrder();
            }
        });
    },
    createOrder: function () {
        var order = {
            CustomerName: $("#txtName").val(),
            CustomerAddress: $("#txtAddress").val(),
            CustomerEmail: $("#txtEmail").val(),
            CustomerMobile: $("#txtPhone").val(),
            CustomerMessage: $("#txtMessage").val(),
            PaymentMethod: "Tiền mặt",
            Status: false,
        }
        $.ajax({
            url: '/Cart/CreateOrder',
            type: 'POST',
            data: {
                orderViewModel: JSON.stringify(order)
            },
            dataType: 'json',
            success: function (res) {
                if (res.status == true) {
                    $("#divCheckout").hide();
                    cart.deleteAll();
                    setTimeout(function () {
                        $("#cartContent").html("Đặt hàng thành công, chúng tôi sẽ liên hệ với bạn trong vòng 24h.");
                    }, 1000);
                }
            }
        })
    },
    getLoginUser: function () {
        $.ajax({
            url: '/Cart/GetUser',
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status == true) {
                    var user = res.data;
                    $("#txtName").val(user.FullName);
                    $("#txtAddress").val(user.Address);
                    $("#txtEmail").val(user.Email);
                    $("#txtPhone").val(user.PhoneNumber);
                }
            }
        })
    },
    getTotalOrder: function () {
        var listTextBoxQuantity = $(".tbQuantity");
        var total = 0;
        $.each(listTextBoxQuantity, function (i, item) {
            total += parseInt($(item).val()) * parseFloat($(item).data('price'));
        });
        if (total > 0)
            return total;
        else
            return 0;
    },
    //addItem: function (productId) {
    //    $.ajax({
    //        url: '/Cart/Add',
    //        data: {
    //            productId: productId
    //        },
    //        type: 'POST',
    //        dataType: 'json',
    //        success: function (res) {
    //            if (res.status == true) {
    //                alert("Thêm sản phẩm thành công.");
    //            }
    //        }
    //    })
    //},
    deleteAll: function () {
        $.ajax({
            url: '/Cart/DeleteAll',
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status == true) {
                    cart.loadData();
                }
            }
        })
    },
    updateAll: function () {
        var cartList = [];
        $.each($(".tbQuantity"), function (i, item) {
            cartList.push({
                productId: $(item).data('id'),
                Quantity: $(item).val()
            });
        });
        $.ajax({
            url: '/Cart/Update',
            data: {
                cartData: JSON.stringify(cartList)
            },
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status == true) {
                    cart.loadData();
                    console.log("Update ok");
                }
            }
        })
    },
    deleteItem: function (productId) {
        $.ajax({
            url: '/Cart/Delete',
            data: {
                productId: productId
            },
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status == true) {
                    cart.loadData();
                }
            }
        })
    },
    loadData: function () {
        $.ajax({
            url: '/Cart/GetAll',
            type: "GET",
            dataType: 'json',
            success: function (res) {
                if (res.status == true) {
                    var data = res.data;
                    var html = '';
                    var template = $("#tplCart").html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ProductId: item.ProductId,
                            ProductName: item.Product.Name,
                            Images: item.Product.Images,
                            Price: numeral(item.Product.Price).format('0,0'),
                            Quantity: item.Quantity,
                            Amount: numeral(item.Quantity * item.Product.Price).format('0,0')
                        });
                    });
                    if (html == '') {
                        $("#cartContent").html("Không có sản phẩm nào trong giỏ hàng");
                    }
                    else {
                        $("#cartBody").html(html);
                    }
                    $("#lblTotalOrder").text(numeral(cart.getTotalOrder()).format('0,0'));
                    cart.registerEvent();
                }
            }
        });
    }
}
cart.init();