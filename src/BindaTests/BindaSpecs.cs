using System;
using BindaTests.NeededObjects;
using Machine.Specifications;
using Binda;

namespace Test
{
    [Subject(typeof(Binder))]
    public class When_binding_windows_form
    {
        Establish context = () =>
                                {
                                    _form = new MySampleForm();
                                    _post = new Post
                                                {
                                                    Title = _title,
                                                    Author = _author,
                                                    Date = SkeetEpoch,
                                                    Body = _body
                                                };
                                };

        Because of = () => { Binder.Bind(_post, _form); };

        It should_take_matching_properties_from_the_post_and_set_them_on_the_form = () =>
                                                                                        {
                                                                                            _form.Title.ShouldEqual(_title);
                                                                                            _form.Author.ShouldEqual(_author);
                                                                                            _form.Date.ShouldEqual(SkeetEpoch);
                                                                                            _form.Body.ShouldEqual(_body);
                                                                                        };

        static MySampleForm _form;
        static Post _post;
        static DateTime SkeetEpoch = DateTime.Parse("6/19/1965");
        static readonly string _body = "Invizible evrybody bere carz bukket flowerz. Nozzing sheeze ghoast funnae cheezeburger scratchin funnae samez apwn. Evrybody ghoast not pour nozbody compewter dum bere. Hunnae how hoi nozzing not luv. Not nozzing samez hoi notise graet bere wtf. Hunnae nom winz evrybody. Partay gravy flowerz evrybody compewters noze. Samez apwn I partay luv sink cheezeburger. Wut nom noze do hoi flowerz partay. Yu bukket saiz teh. Scratchin haz evrybody not evrybody compewters. Nuthing ghoast compewters u thx ya.";
        static readonly string _author = "Dr. Anderson Silva";
        static readonly string _title = "Why Medical Unit Tests Fail";
    }
}