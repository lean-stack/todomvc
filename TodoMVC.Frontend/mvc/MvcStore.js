(function (netto) {

    var baseUrl = 'http://localhost:50000/mvc/todos';

    // Klasse MvcStore
    function MvcStore() {
        netto.TodoStore.apply(this, arguments);
    }
    MvcStore.prototype = Object.create(netto.TodoStore.prototype);

    MvcStore.prototype.getAll = function () {
        var p = new netto.Promise();

        netto.ajax('GET', baseUrl, null)
            .then(
                function (todos) { p.resolve(todos); },
                function (err) { p.reject(err); }
             );

        return p;
    };

    MvcStore.prototype.create = function (txt) {
        var p = new netto.Promise();

        netto.ajax('POST', baseUrl + '/Create', { txt: txt }).
            then(
                function (todo) { p.resolve(todo); },
                function (err) { p.reject(err); }
            );

        return p;
    };

    MvcStore.prototype.update = function (todo) {
        var p = new netto.Promise();

        netto.ajax('POST', baseUrl + '/Edit', todo).
            then(
                function (todo) { p.resolve(todo); },
                function (err) { p.reject(err); }
            );

        return p;
    };

    MvcStore.prototype.delete = function (id) {
        var p = new netto.Promise();

        netto.ajax('POST', baseUrl + '/Delete', { id: id }).
            then(
                function (result) { p.resolve(); },
                function (err) { p.reject(err); }
            );

        return p;
    };

    netto.MvcStore = MvcStore;
    window.netto = netto;

})(window.netto || {});