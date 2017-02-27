//Function to validate checkboxes 

function submitWith() {
    var checkedCompanyCount = $("#divCompanyLoc input:checked").length;
    var checkedInterviewerCount = $("#divInterviewerDesc input:checked").length;
    var validCompanyCount = checkedCompanyCount > 0;
    var validInterviewerCount = checkedInterviewerCount > 0
    var value= true;
    if (!validCompanyCount) {
        $('#validationMessageForCompanyLoc').html('');
        $('#validationMessageForCompanyLoc').html('You must select at least one option');
        value = false;
    }
    else
    {
        $('#validationMessageForCompanyLoc').html('');

    }
    if (!validInterviewerCount) {
        $('#validationMessageForInterviewDesc').html('');
        $('#validationMessageForInterviewDesc').html('You must select at least one option');
        value = false;
    }
    else {
        $('#validationMessageForInterviewDesc').html('');

    }
    
    return value;
}
