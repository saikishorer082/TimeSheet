(function () {
    'use strict';
    angular.module("timeSheet.main")
        .controller("mainCtrl", function ($scope,$state,$rootScope,authFact) {
            $scope.appNav = 'AngularApp/app/main/navbar.tpl.html';
            $scope.brandname = "Sunray Informatics";

            

            $scope.clickMe = function () {
                console.log($scope);
            }
            $scope.loadLogin = function () {
                //$scope.load = 'AngularApp/app/login/login.tpl.html'
                $state.go('login');
            }
            
            $scope.$on('Login_Success', function (event, args) {
                console.log(args);
                $scope.userInfo = args.data;
                $scope.isAuthenticated = true;

            });
            $scope.$on('User_Info', function (event, args) {
                console.log(args);
                $scope.UserInfoDB = args.data1;
                //$scope.userInfoDB = authFact.getUserInfo();
            });
            $scope.userInfoDB = authFact.getUserInfo();
            $scope.loadLogin();
            $scope.logOut = function () {
                $scope.userInfoDB = authFact.logOffUser();
                $scope.isAuthenticated = false;
            }
        })
}
)();