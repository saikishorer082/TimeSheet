
angular.module("timeSheet", [
    "timeSheet.common",
    "timeSheet.main",
    "timeSheet.login",
    "timeSheet.profile",
    "timeSheet.newTimeEntry",
    "timeSheet.viewTimeEntry",
    "timeSheet.securityQue",
    "timeSheet.signUp",
    "ui.router"
]);
angular.module("timeSheet")
.config(function ($stateProvider,$urlRouterProvider) {
    $stateProvider
        .state("main", {
            url: "/main",
            templateUrl: "AngularApp/app/main/navbar.tpl.html",
            controller: "mainCtrl"
        })
    .state("login", {
        url: "/login",
        templateUrl: "AngularApp/app/login/login.tpl.html",
        controller: "loginCtrl"
    })
     .state("profile", {
         url: "/profile",
         templateUrl: "AngularApp/app/profile/profile.html",
         controller: "profileCtrl"
     })
     .state("viewtimeentry", {
         url: "/viewtimeentry",
         templateUrl: "AngularApp/app/viewtimeentry/viewtimeentry.tpl.html",
         controller: "viewTimeEntryCtrl"
     })
    .state("newTimeEntry", {
        url: "/newTimeEntry",
        templateUrl: "AngularApp/app/NewTimeEntry/newTimeEntry.tpl.html",
        controller: "newTimeEntryCtrl"
    })
    $urlRouterProvider.otherwise("/login");
});