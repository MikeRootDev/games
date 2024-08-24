import { AfterViewInit, ElementRef, Renderer2, Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'lib-minesweeper',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './minesweeper.component.html',
  styleUrl: './minesweeper.component.css',
})
export class MinesweeperComponent implements AfterViewInit {
  constructor(private elRef: ElementRef, private renderer: Renderer2) {}

  ngAfterViewInit(): void {
    this.fillParentWithDivs();
  }

  fillParentWithDivs(): void {
    const parentElement = this.elRef.nativeElement.querySelector('#gameContainer');
    const parentWidth = parentElement.clientWidth;
    const parentHeight = parentElement.clientHeight;
    const divWidth = 50;
    const divHeight = 50;
    let currentWidth = 0;
    let currentHeight = 0;
    let counter = 0;
  
    while (currentHeight + divHeight <= parentHeight) {
      while (currentWidth + divWidth <= parentWidth) {
        counter++;
        const div = this.renderer.createElement('div');
        this.renderer.addClass(div, 'block');
        this.renderer.setStyle(div, 'height', `${divHeight}px`);
        this.renderer.setStyle(div, 'float', 'left'); // Ensures that divs align next to each other
        const className = (counter % 2 === 1) ? 'block-style-one' : 'block-style-two';
        this.renderer.addClass(div, className);
        this.renderer.appendChild(parentElement, div);
        currentWidth += divWidth;
      }
      currentWidth = 0; // Reset width for new row
      counter++;
      currentHeight += divHeight;
    }
  }
}
