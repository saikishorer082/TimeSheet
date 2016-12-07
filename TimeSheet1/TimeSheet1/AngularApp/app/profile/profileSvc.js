(function () {
    'use strict';
    var profileSvc = function ($http, $q,authFact) {
        this.getProfile = function (username) {
            var dfd = $q.defer();
            $http.get("api/Profile/"+ username)
            .then(function (response) {
                if (response.status == 200 && response.statusText == "OK") {
                   
                    dfd.resolve(response.data)
                }
                else {
                   dfd.reject("UnAuthenticated user");
                    
                }
            })
                          .catch(function (response) {
                              dfd.reject("Error Occurred");
                          });
            return dfd.promise;
        }
        this.updateProfile = function (FirstName,P) {
            var dfd = $q.defer();
            $http.put("api/Profile/" +FirstName,P)
            .then(function (response) {
                dfd.resolve(response);
            })
            .catch(function (response) {
                dfd.reject("Error Occurred");
            });
            return dfd.promise;
        }
    };
    angular.module("timeSheet.profile").service("profileSvc", ["$http", "$q", profileSvc]);
})();