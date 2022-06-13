namespace QuestionVisualisation.UserControls.QuestionDisplay.States
{
    // TODO: change interface of onctext to common interface with:
    // * update function
    // * transition function
    // * key press event function

    public interface IStateContext 
    {
        public void ChangeState(QuestionDisplayUserControlState newState);
    }
}
