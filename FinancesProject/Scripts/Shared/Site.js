var WarningManager = {
    showWarning: function (message) {
        $('#warning')
      .html(message)
      .fadeIn('slow')
      //.insertBefore($('#page-content'))  //<== wherever you want it to show
      .animate({ opacity: 1.0 }, 3000)     //<== wait 3 sec before fading out
      .fadeOut('slow');
    }
};