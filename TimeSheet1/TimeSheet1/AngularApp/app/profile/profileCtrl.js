(function () {
    "use strict";
    angular.module("timeSheet.profile")
    .controller("profileCtrl", function ($scope, profileSvc, $state, $rootScope,authFact) {
        $scope.profile = function () {
            profileSvc.getProfile($scope.userInfo.UserName)
                .then(function (response) {
                    authFact.setUserInfo(response);
                    $scope.P = authFact.getUserInfo();
                    $rootScope.$broadcast("User_Info",{data1:$scope.P});
                })
            .catch(function (errorResponse) {
                console.log(errorResponse);
            })

        }
        $scope.profile();
        $scope.save = function (FirstName,P) {
            profileSvc.updateProfile(FirstName,P)
            .then(function (response) {
                console.log(response);
                alert("Updated Successfully");
            })
            .catch(function (er) {
                console.log(er);
            })
        }
    })
})();