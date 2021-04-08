$(document).ready(function () {
    DefaultTextBinding();
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(DefaultTextBinding);
    if ($('li.active').length > 0) {
        $('li.active').parents("li:last").addClass('active');
    }
});
function DefaultTextBinding() {
    $('.default-value').each(function () {
        var default_value = this.value;
        $(this).focus(function () {
            if (this.value == default_value) {
                this.value = '';
            }
        });
        $(this).blur(function () {
            if (this.value == '') {
                this.value = default_value;
            }
        });
    });
}