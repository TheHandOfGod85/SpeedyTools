import { Component } from '@angular/core';

@Component({
  selector: 'app-footer',
  template: `
    <div
      class="d-flex flex-column flex-md-row text-center text-md-start justify-content-between py-4 px-4 px-xl-5 bg-primary"
    >
      <div class="text-white mb-3 mb-md-0">
        Copyright © 2020. All rights reserved.
      </div>
    </div>
  `,
  styleUrls: ['./footer.component.css'],
})
export class FooterComponent {}
