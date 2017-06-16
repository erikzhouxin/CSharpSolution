var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);
app.config(function ($routeProvider) {
    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/Content/Scripts/ZApi/TestAngularJs/views/home.html"
    });
    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/Content/Scripts/ZApi/TestAngularJs/views/login.html"
    });
    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/Content/Scripts/ZApi/TestAngularJs/views/signup.html"
    });
    $routeProvider.when("/orders", {
        controller: "ordersController",
        templateUrl: "/Content/Scripts/ZApi/TestAngularJs/views/orders.html"
    });
    $routeProvider.when("/refresh", {
        controller: "refreshController",
        templateUrl: "/Content/Scripts/ZApi/TestAngularJs/views/refresh.html"
    });
    $routeProvider.when("/tokens", {
        controller: "tokensManagerController",
        templateUrl: "/Content/Scripts/ZApi/TestAngularJs/views/tokens.html"
    });
    $routeProvider.otherwise({ redirectTo: "/home" });
});
app.constant('ngAuthSettings', {
    apiServiceBaseUri: 'http://' + location.host + '/',
    client_id: 'xishuai'
});
app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});
app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


