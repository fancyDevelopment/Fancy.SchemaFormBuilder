(function () {
    "use strict";

    angular.module("fancy.schema-form-builder-studio")
        .config(["$stateProvider", function ($stateProvider) {

            $stateProvider
                .state("root", {
                    abstract: true,
                    controller: "RootController",
                    controllerAs: "rootVm",
                    templateUrl: "/app/layout/root.tpl.html"
                });

        }]);

})();