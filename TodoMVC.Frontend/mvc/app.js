(function (window) {
	'use strict';

	var localTodos = [];

	// Your starting point. Enjoy the ride and choose your store here!
	var store = new netto.MvcStore();

    // Query caching
	var todoTxt = document.querySelector('.new-todo');
	var todoLst = document.querySelector('.todo-list');

    // App starting
	store.getAll().then(function (todos) {
	    todos.forEach(function (todo) {
	        localTodos[todo.id] = todo;
	        addTodo(todo);
	    });
	});

    // Events
	todoTxt.addEventListener('keypress', function (ev) {
	    if (ev.keyCode === 13) {
	        var txt = todoTxt.value.trim();
	        if (txt.length > 0) {
	            store.create(txt).then(addTodo);
	        }
	        todoTxt.value = '';
	    }
	});

	function renderView() {

	}
	function addTodo(todo) {
	    var tpl = document.getElementById('todoTpl').innerHTML;

	    var wrapper = document.createElement('ul');
	    wrapper.innerHTML = tpl;

	    var li = wrapper.querySelector('li');
	    todo.done && li.classList.add('completed');
	    li.setAttribute('data-id', todo.id);
	    wrapper.querySelector('label').innerHTML = todo.txt;
	    wrapper.querySelector('.edit').value = todo.txt;

	    todoLst.appendChild(li);
	}   

})(window);
