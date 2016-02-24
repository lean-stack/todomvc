(function (netto) {

    // Klasse Todo
    function Todo(txt, done) {
        this.id = -1;
        this.txt = txt;
        this.done = done || false;
    }

    // Klasse TodoStore
    function TodoStore() {
        this.render = new Event('renderView');
    }

    TodoStore.prototype = {
        getAll: function () { },
        create: function (txt) { },
        update: function (todo) { },
        delete: function (id) { }
    }

    netto.Todo = Todo;
    netto.TodoStore = TodoStore;
    window.netto = netto;
})(window.netto || {});