import { Route } from '@angular/router';

export const appRoutes: Route[] = [
    {
        path: 'minesweeper',
        loadComponent: () => 
            import('@games/minesweeper').then((m) => m.MinesweeperComponent),
    }
];
