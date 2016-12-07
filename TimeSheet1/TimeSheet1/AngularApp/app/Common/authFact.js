(function () {
    'use strict';
    angular.module('timeSheet.common',[])
       .factory("authFact", function () {
           var userDetails = {};
           var resetUserDetails = function () {
               userDetails = "";
               return userDetails;
           };
           var setUserDetails = function (details) {
               userDetails = details;
           };
           var getUserDetails = function () {
               return userDetails;
           };
           return {
               getUserInfo: getUserDetails,
               setUserInfo: setUserDetails,
               logOffUser: resetUserDetails
           };
       });
})();

