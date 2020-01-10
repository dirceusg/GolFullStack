import {Routes} from '@angular/router';
import {HomeComponent} from './navegacao/home/home.component';
import {SobreComponent} from './informacao/sobre/sobre.component';
import {ContatoComponent} from './informacao/contato/contato.component';
import { ListaProdutoComponent } from './produtos/lista-produto/lista-produto.component';





export const rootRouterConfig : Routes = [
  { path: '', redirectTo:'/home', pathMatch:'full'},
  { path: 'home', component : HomeComponent},
  { path: 'sobre', component : SobreComponent},
  { path: 'contato', component : ContatoComponent},
  { path: 'listaproduto', component : ListaProdutoComponent}


];