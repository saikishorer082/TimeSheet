(function () {
    'use strict';
    var loginSvc = function ($http, $q) {
        this.authenticateUser = function (userDetails) {
            var dfd = $q.defer();
            $http.post("api/Login", userDetails)
                          .then(function (response) {
                              if (response.status == 200 && response.statusText == "OK" && response.data==true) {

                                  dfd.resolve(response.data);
                              }
                              else {
                                  dfd.reject("Invalid Credentials");
                              }
                          })
                          .catch(function (response) {
                              dfd.reject("Error Occurred");
                          });
            return dfd.promise;
        }
        //this.getProfile = function (GetProfiletbl) {
        //    var dfd = $q.defer();
        //    $http.get("api/Profiletbls", GetProfiletbl)
        //    .then(function (response) {
        //        if (response.status == 200 && response.statusText == "OK") {
        //            dfd.resolve(response.data)
        //            console.log(response.data);
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
    };
    angular.module("timeSheet.login").service("loginSvc", ["$http", "$q", loginSvc]);
})();