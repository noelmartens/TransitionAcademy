"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.ListComponent = void 0;
var core_1 = require("@angular/core");
var operators_1 = require("rxjs/operators");
var ListComponent = /** @class */ (function () {
    function ListComponent(accountService) {
        this.accountService = accountService;
        this.users = null;
    }
    ListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.accountService.getAll()
            .pipe(operators_1.first())
            .subscribe(function (users) { return _this.users = users; });
    };
    ListComponent.prototype.deleteUser = function (id) {
        var _this = this;
        var user = this.users.find(function (x) { return x.id === id; });
        user.isDeleting = true;
        this.accountService["delete"](id)
            .pipe(operators_1.first())
            .subscribe(function () { return _this.users = _this.users.filter(function (x) { return x.id !== id; }); });
    };
    ListComponent = __decorate([
        core_1.Component({ templateUrl: 'list.component.html' })
    ], ListComponent);
    return ListComponent;
}());
exports.ListComponent = ListComponent;
