(function () {
    "use strict";

    var myApp = angular.module("fancy.schema-form-builder-studio", ["ui.router", "schemaForm", "ui.ace"]);

    myApp.config(["$urlRouterProvider", function ($urlRouterProvider) {

        // For any unmatched url, redirect to /home
        $urlRouterProvider.otherwise("/live-editor");

    }]);

})();