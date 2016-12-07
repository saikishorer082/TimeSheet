(function () {
    "use strict";
    angular.module("timeSheet.newTimeEntry")
    .controller("newTimeEntryCtrl", function ($scope, newTimeEntrySvc) {
        console.log("i am newTimeEntry controller");
        $scope.clients = ["orbit", "BMW", "AUDI", "Chase"];
        $scope.Tasks = ["Developing", "TesTing"];
        $scope.projects = ["Android Application", "IOS Application", "Windows Application"]
        $scope.subprojects = ["Cricket", "Mobile Strike", "IDM"];
        
        $scope.saveNewTimeEntry = function (newUser) {
            newTimeEntrySvc.timeEntry(newUser)
                .then(function (response) {
                    console.log(response);
                    alert("Updated Successfully");
                })
            .catch(function (er) {
                console.log(er);
                alert("Give exact details");
            });
        }
        $scope.recentlyAdded = function () {
            newTimeEntrySvc.recentlyAdded()

                .then(function (response) {
                    console.log(response);
                    $scope.newentry = response.data;
                })
            .catch(function (er) {
                console.log(er);
            });
        }
        $scope.edit = function (date) {
            newTimeEntrySvc.edit(date)

                .then(function (response) {
                    console.log(response);
                    $scope.user = response;
                })
            .catch(function (er) {
                console.log(er);
            });
        }
        $scope.delete = function (date) {
            newTimeEntrySvc.delete(date)

                .then(function (response) {
                    console.log(response);
                    alert("Data Deleted Successfully");
                })
            .catch(function (er) {
                console.log(er);
                alert("Data Not Found");
            });
        }
        })
})();