var myApp = angular.module('chemApp', []);

myApp.controller('ChemicalsController', ['$scope', '$http', '$sce', function ($scope, $http, $sce) {
    
    $scope.init = function (chemicals) {
        $scope.chemicals = chemicals;
        $scope.chemicalSelect = "";
    }

    $scope.getChemical = function () {
        $scope.content = null;
        $http.get('api/chemicals/' + $scope.chemicalSelect.ProductId, { responseType: 'arraybuffer' }).then(function (successResponse) {
            var pdfBinary = successResponse.data;
            var file = new Blob([pdfBinary], { type: 'application/pdf' });
            var fileUrl = URL.createObjectURL(file);
            $scope.content = $sce.trustAsResourceUrl(fileUrl);
        });
    }
}]);