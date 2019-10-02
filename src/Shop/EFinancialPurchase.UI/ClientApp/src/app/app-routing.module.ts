import { NgModule } from "@angular/core";
import { HomeComponent } from "./components/home/home.component";
import { Routes, RouterModule } from "@angular/router";
import { ShoppingComponent } from "./components/shopping/shopping.component";
import { ShoppingDetailsComponent } from "./components/shopping/details/shopping.details.component";

const ROUTES: Routes = [
    { path: 'home', component: HomeComponent, pathMatch: 'full' },
    { path: 'compras', component: ShoppingComponent, data: { title: 'ePurchaseFinancial - Shopping' } },
    { path: 'compras/novo', component: ShoppingDetailsComponent, data: { title: 'ePurchaseFinancial - Shopping' } }
];

@NgModule({
    imports: [
        RouterModule.forRoot(ROUTES)
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }