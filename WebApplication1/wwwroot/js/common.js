var commonJS = {
    formatDate(date) {
        if (date && !isNaN(date.getDate())) {
            var day = date.getDate();
            var month = date.getMonth() + 1;
            var year = date.getFullYear();
            month = (month < 10) ? "0" + month : month;
            day = (day < 10) ? "0" + day : day;
            return day + "/" + month + "/" + year;
        }
        return null;
    },
    formatDateSt(date) {
        if (date && !isNaN(date.getDate())) {
            var day = date.getDate();
            var month = date.getMonth() + 1;
            var year = date.getFullYear();
            month = (month < 10) ? "0" + month : month;
            day = (day < 10) ? "0" + day : day;
            return year + "/" + month + "/" + day;
        }
        return null;
    },
    formatMoney(money) {
        if (money || money == 0) {
            return money.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.');
        }
        return null;
    }
}