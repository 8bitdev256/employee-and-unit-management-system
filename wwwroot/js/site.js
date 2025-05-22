// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', event => {
    const newColorScheme = event.matches ? "dark" : "light";
    const htmlTag = document.querySelector('html');
    const bodyTag = document.querySelector('body');
    htmlTag.setAttribute('data-bs-theme', newColorScheme);
    bodyTag.setAttribute('data-bs-theme', newColorScheme);
});