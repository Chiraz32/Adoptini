// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


const profileIcon = document.querySelector('.profile-container')
const dropdownMenu = document.querySelector('.profile-dropdown')
const cancelDelete = document.querySelector('.cancel-delete');
const deleteButton = document.querySelector('.delete-button')
const modal = document.querySelector('.delete-user-modal');
profileIcon.addEventListener('click', (e) => dropdownMenu.classList.toggle('open'));
deleteButton.addEventListener('click', (e) => modal.classList.add('open'));

cancelDelete.addEventListener('click', (e) => modal.classList.remove('open'));