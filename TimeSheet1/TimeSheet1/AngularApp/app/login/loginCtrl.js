(function () {
    'use strict';
    angular.module("timeSheet.login")
    .controller("loginCtrl", function ($scope, loginSvc,$state,$rootScope) {
        $scope.login = {
            companyID:"",
            UserName: "",
            Password: "",
            department:""
        }
        $scope.loginUser = function () {
            loginSvc.authenticateUser($scope.login)
                .then(function (response) {
                    console.log(response);
                    $rootScope.$broadcast('Login_Success', { data: $scope.login });
                    $state.go('profile');
                })
            .catch(function (errorResponse) {
                alert(errorResponse);
            })

        }

    });

}

)();