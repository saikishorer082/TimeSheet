(function () {
    'use strict';
    var newTimeEntrySvc = function ($http, $q) {
        //this.getProfile = function (newUser) {
        //    var dfd = $q.defer();
        //    $http.put("api/Profile/" + username)
        //    .then(function (response) {
        //        if (response.status == 200 && response.statusText == "OK") {

        //            dfd.resolve(response.data)
        //        }
        //        else {
        //            dfd.reject("UnAuthenticated user");

        //        }
        //    })
        //                  .catch(function (response) {
        //                      dfd.reject("Error Occurred");
        //                  });
        //    return dfd.promise;
        //}
        this.timeEntry = function (newUser) {
            var dfd = $q.defer();
            $http.post("api/NewTimeEntrytbls",newUser)
            .then(function (response) {
                dfd.resolve(response);
            })
            .catch(function (response) {
                dfd.reject("Error Occurred");
            });
            return dfd.promise;
        }
        this.recentlyAdded = function () {
            var dfd = $q.defer();
            $http.get("api/NewTimeEntrytbls")
            .then(function (response) {
                dfd.resolve(response);
            })
            .catch(function (response) {
                dfd.reject("Error Occurred");
            });
            return dfd.promise;
        }
        this.edit = function (date) {
            var dfd = $q.defer(date);
            $http.get("api/NewTimeEntrytbls/"+date)
            .then(function (response) {
                dfd.resolve(response);
            })
            .catch(function (response) {
                dfd.reject("Error Occurred");
            });
            return dfd.promise;
        }
        this.delete = function (date) {
            var dfd = $q.defer(date);
            $http.delete("api/NewTimeEntrytbls/" + date)
            .then(function (response) {
                dfd.resolve(response);
            })
            .catch(function (response) {
                dfd.reject("Error Occurred");
            });
            return dfd.promise;
        }
    };
    angular.module("timeSheet.newTimeEntry").service("newTimeEntrySvc", ["$http", "$q", newTimeEntrySvc]);
})();