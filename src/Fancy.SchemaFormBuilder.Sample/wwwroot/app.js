(function () {
    "use strict";

	// Create a new angular app -> don't forget to specify a dependency to the "schemaForm" module
    var myApp = angular.module("fancy.schema-form-builder-sample", ["schemaForm"]);

	// Create the main controller for the sample app
    myApp.controller("MainController", ["$http", "$scope", function($http, $scope) {

	    var currentEmployeeId = null;

	    $scope.allEmployees = new Array();

		// Load the metadata for a new employee
	    $http.get("employees/create").success(function(data) {
		    $scope.formInfo = data;
	    });

		// This function gets called by the form on submission
	    $scope.submitForm = function(form) {

			// First we broadcast an event to trigger validation of all fields
			$scope.$broadcast('schemaFormValidate');

			// Then we check if the form is valid
		    if (form.$valid) {
				// The form ist valid -> update the resource on the server
			    if (currentEmployeeId) {
					// The employee already exists -> call the update method
				    $http.post("employees/" + currentEmployeeId, $scope.formInfo.Data).success(function() {
					    loadAllEmployees();
				    });
			    } else {
					// The employee is a new one -> create a new resource on the server
				    $http.put("employees", $scope.formInfo.Data).success(function() {
					    loadAllEmployees();
				    });
			    }

				// Reset the form to an empty employee
				currentEmployeeId = null;
				$scope.formInfo.Data = {};
		    }
	    };

		// Loads a specific employee for edit into the form
		$scope.loadEmployeeForEdit = function(employeeId) {
		    $http.get("employees/" + employeeId + "/edit").success(function(data) {
			    currentEmployeeId = employeeId;
				$scope.formInfo = data;
		    });
	    }

		// A helper functio to load all employees
	    function loadAllEmployees() {
		    $http.get("employees").success(function(data) {
				$scope.allEmployees = data;
		    });
	    }

    }]);

})();