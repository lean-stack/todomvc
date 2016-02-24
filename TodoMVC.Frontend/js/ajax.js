(function (netto) {

    function ajax(method,url,data) {

        var form_data = new FormData();

        for (var key in data) {
            form_data.append(key, data[key]);
        }

        var p = new netto.Promise();

        var xhr = new XMLHttpRequest();
        xhr.open(method, url, true);

        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    var data = JSON.parse(xhr.responseText);
                    p.resolve(data);
                } else {
                    p.reject({ status: xhr.status, error: xhr.statusText });
                }
            }
        }

        xhr.send(form_data);

        return p;
    }

    netto.ajax = ajax;
    window.netto = netto;

})(window.netto || {});