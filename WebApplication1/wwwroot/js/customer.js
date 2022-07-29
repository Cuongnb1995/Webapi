$(document).ready(function () {
    var customer = new CustomerJS();
});

class CustomerJS {
    constructor() {
        try {
            this.loadData();
            this.intevent();
        }
        catch (error) {
        }
    }

    intevent() {
        $('#btn-add').on("click", this.btnAddClick);
        $('.form-header-close, #ffr-btn-cancel').on("click", this.btnCloseClick.bind(this));
        $("#btnSaveDetail").on("click", this.saveData.bind(this));
        $("table").on("click", "tbody tr", this.rowOnClick);
        $("#btn-delete").on("click", this.btnDelClick);
        $("#btn-edit").on("click", this.btnEditClick.bind(this));
        $(document).on('click', '.pagingPage a', this.btnPagingClick.bind(this));
    }

    btnPagingClick(sender) {
        var page = $(sender.target).data("page");
        this.loadData(page);
    }

    btnEditClick() {
        var me = this;
        var rowId = $('tr.row-selected').data("id");
        if (rowId != undefined) {
            $.ajax({
                url: "/api/Employee/" + rowId,
                method: "GET",
                dataType: "json",
                contentType: "application/json",
            }).done(function (res) {
                $('#textEmployeeCode').val(res.employeeCode);
                $('#textFullName').val(res.fullName);
                $('#textDateOfBirth').val(res.dateOfBirth != null ? res.dateOfBirth.split('T')[0] : "");
                $('#gender').val(res.gender);
                $('#textEmail').val(res.email);
                $('#textPhoneNumber').val(res.phoneNumber);
                $('#textCitizenIdentityCode').val(res.citizenIdentityCode);
                $('#textCitizebIdentityDate').val(res.citizebIdentityDate != null ? res.citizebIdentityDate.split('T')[0] : "");
                $('#textCitizebIdentityPlace').val(res.citizebIdentityPlace);
                $('#textPositionId').val(res.positionId);
                $('#textDepartmentId').val(res.departmentId);
                $('#textSelfTaxCode').val(res.selfTaxCode);
                $('#textSalary').val(res.salary);
                $('#textJoinDate').val(res.joinDate != null ? res.joinDate.split('T')[0] : "");
                $('#textWorkState').val(res.workState);
            }).fail(function () {
                alert("Lỗi");
            });
            $('.form-dialog').show();
        }
        else {
            alert("Vui long chon dong muon sua!");
        }
    }
    rowOnClick() {
        this.classList.add("row-selected");
        $(this).siblings().removeClass("row-selected");
    }

    btnDelClick() {
        var me = this;
        var rowselect = $('tr.row-selected');
        var rowId = $('tr.row-selected').data("id");
        if (rowId != undefined) {
            var b = confirm("ban co chac chan xoa khong?");
        }
        if (b == true) {
            console.log(rowId);
            rowselect.remove();
            $.ajax({
                url: "/api/Employee/" + rowId,
                method: "DELETE",
            }).done(function (res) {
                me.loadData();
            }).fail(function () {
                alert("Lỗi");
            });
        }
    }

    btnAddClick() {
        $('tr').removeClass("row-selected");
        $('.form-dialog').show();
    }

    btnCloseClick() {
        $('.form-dialog').hide();
        this.clearData();
    }

    clearData() {
        $(".form-dialog input").val("");
        $(".form-dialog option").prop("selected", false).trigger("change");
    }

    loadData(page) {
        var _page = "";
        if (page != undefined) {
            _page = page;
        }
        $('.gird tbody').empty();
        $("#pager").empty();
        $.ajax({
            url: '/api/Employee?page=' + _page,
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                var currentPage = res.pager.currentPage;
                var startPage = res.pager.startPage;
                var endPage = res.pager.endPage;
                var totalPages = res.pager.totalPages;
                $.each(res.viewEmployee, function (index, item) {
                    var customerInfoHTML = `<tr data-id="${item.employeeId}">
                                <td>${item.employeeCode}</td>
                                <td>${item.fullName}</td>
                                <td>${item.genderName}</td>
                                <td>${item.dateOfBirth != null ? commonJS.formatDate(new Date(item.dateOfBirth)) : ""}</td>
                                <td>${item.phoneNumber}</td>
                                <td>${item.email}</td>
                                <td>${item.position}</td>
                                <td>${item.department}</td>
                                <td>${commonJS.formatMoney(item.salary) || ''}</td>
                                <td>${item.workStateName}</td>
                            </tr>`;
                    $('.gird tbody').append(customerInfoHTML);
                });
                var listpagingHTML = "";
                for (var i = startPage; i <= endPage; i++) {
                    listpagingHTML += ` <li class="pagingPage"><a style="${currentPage == i ? "color:red" : "" };" data-page="${i}">${i}</a></li>`;
                }
                var firstpagingHTML = "";
                if (currentPage > 1) {
                    firstpagingHTML = `<li class="pagingPage"><a data-page="${1}">First</a> </li>
                     <li class="pagingPage"><a data-page="${currentPage - 1}">Previous</a> </li>`;
                }
                var endpagingHTML = "";
                if (currentPage < totalPages) {
                    endpagingHTML = `<li class="pagingPage"><a data-page="${currentPage + 1}">Next</a> </li>
                     <li class="pagingPage"><a data-page="${endPage}">Last</a></li>`;
                }
                var pagingHTML = firstpagingHTML + listpagingHTML + endpagingHTML;
                $("#pager").append(pagingHTML);
            }
        });
    }
    saveData() {
        var me = this;
        var employeeCode = $('#textEmployeeCode').val(),
            fullName = $('#textFullName').val(),
            dateOfBirth = new Date($('#textDateOfBirth').val()),
            gender = parseInt($('#textGender').val()),
            email = $('#textEmail').val(),
            phoneNumber = $('#textPhoneNumber').val(),
            citizenIdentityCode = $('#textCitizenIdentityCode').val(),
            citizebIdentityDate = new Date($('#textCitizebIdentityDate').val()),
            citizebIdentityPlace = $('#textCitizebIdentityPlace').val(),
            positionId = parseInt($('#textPositionId').val()),
            departmentId = parseInt($('#textDepartmentId').val()),
            selfTaxCode = $('#textSelfTaxCode').val(),
            salary = parseFloat($('#textSalary').val()),
            joinDate = new Date($('#textJoinDate').val()),
            workState = parseInt($('#textWorkState').val());

        var employee = {
            EmployeeCode: employeeCode,
            FullName: fullName,
            DateOfBirth: dateOfBirth,
            Gender: gender,
            Email: email,
            PhoneNumber: phoneNumber,
            CitizenIdentityCode: citizenIdentityCode,
            CitizebIdentityDate: citizebIdentityDate,
            CitizebIdentityPlace: citizebIdentityPlace,
            PositionId: positionId,
            DepartmentId: departmentId,
            SelfTaxCode: selfTaxCode,
            Salary: salary,
            JoinDate: joinDate,
            WorkState: workState
        };
        var rowId = $('tr.row-selected').data("id");
        if (rowId == undefined) {
            $.ajax({
                url: "/api/Employee",
                method: "POST",
                data: JSON.stringify(employee),
                dataType: "text",
                contentType: "application/json"
            }).done(function (res) {
                alert("Cat thanh cong");
                me.btnCloseClick();
                me.loadData();
            }).fail(function (res) {
                debugger
            });
        }
        else {
            employee.employeeId = parseInt(rowId);
            $.ajax({
                url: "/api/Employee/" + rowId,
                method: "PUT",
                data: JSON.stringify(employee),
                dataType: "text",
                contentType: "application/json"
            }).done(function (res) {
                alert("Cat thanh cong");
                me.btnCloseClick();
                me.loadData();
            }).fail(function (res) {
                debugger
            });
        }

    }
}