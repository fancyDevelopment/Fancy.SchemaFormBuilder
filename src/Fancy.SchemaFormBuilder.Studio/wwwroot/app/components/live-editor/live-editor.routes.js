(function () {
    "use strict";

    angular.module("fancy.schema-form-builder-studio")
        .config(["$stateProvider", function ($stateProvider) {

            $stateProvider
                .state("live-editor", {
                    parent: "root",
                    url: "/live-editor",
                    controller: "LiveEditorController",
                    controllerAs: "vm",
                    templateUrl: "/app/components/live-editor/live-editor.tpl.html"
                });

        }]);

})();