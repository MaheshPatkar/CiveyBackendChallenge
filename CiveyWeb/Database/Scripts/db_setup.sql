create table poll
(
    id           bigserial
        constraint poll_pk
            primary key,
    text         text    not null,
    multi_choice boolean not null
);

alter table poll
    owner to postgres;

create table answer
(
    id      bigserial
        constraint answer_pk
            primary key,
    text    text not null,
    poll_id bigserial
        constraint answer_poll_id_fk
            references poll
);

alter table answer
    owner to postgres;

INSERT INTO public.poll (id, text, multi_choice) VALUES (1, 'What is your favourite kind of beer', false);
INSERT INTO public.poll (id, text, multi_choice) VALUES (2, 'Which movie genres do you like', true);
INSERT INTO public.poll (id, text, multi_choice) VALUES (3, 'What is your favourite Star Wars character', false);
INSERT INTO public.poll (id, text, multi_choice) VALUES (4, 'what is the answer to life the universe and everything', false);

INSERT INTO public.answer (id, text, poll_id) VALUES (1, 'Pils', 1);
INSERT INTO public.answer (id, text, poll_id) VALUES (2, 'Helles', 1);
INSERT INTO public.answer (id, text, poll_id) VALUES (3, 'IPA', 1);
INSERT INTO public.answer (id, text, poll_id) VALUES (4, 'Dark Lager', 1);
INSERT INTO public.answer (id, text, poll_id) VALUES (5, 'Trappist', 1);
INSERT INTO public.answer (id, text, poll_id) VALUES (6, 'Comedy', 2);
INSERT INTO public.answer (id, text, poll_id) VALUES (7, 'Drama', 2);
INSERT INTO public.answer (id, text, poll_id) VALUES (8, 'Thriller', 2);
INSERT INTO public.answer (id, text, poll_id) VALUES (9, 'Documentary', 2);
INSERT INTO public.answer (id, text, poll_id) VALUES (10, 'Horror', 2);
INSERT INTO public.answer (id, text, poll_id) VALUES (11, 'Luke', 3);
INSERT INTO public.answer (id, text, poll_id) VALUES (12, 'Lea', 3);
INSERT INTO public.answer (id, text, poll_id) VALUES (13, 'Dart Vader', 3);
INSERT INTO public.answer (id, text, poll_id) VALUES (14, 'R2D2', 3);
INSERT INTO public.answer (id, text, poll_id) VALUES (15, 'Han Solo ', 3);
INSERT INTO public.answer (id, text, poll_id) VALUES (16, 'Emperor', 3);
INSERT INTO public.answer (id, text, poll_id) VALUES (17, '32', 4);
INSERT INTO public.answer (id, text, poll_id) VALUES (18, '42', 4);
INSERT INTO public.answer (id, text, poll_id) VALUES (19, '47', 4);
INSERT INTO public.answer (id, text, poll_id) VALUES (20, '49', 4);